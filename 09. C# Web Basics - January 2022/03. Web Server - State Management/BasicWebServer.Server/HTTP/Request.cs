﻿namespace BasicWebServer.Server.HTTP
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Request
    {
        private static Dictionary<string, Session> Sessions = new();
        
        public Method Method { get; private set; }

        public string Url { get; private set; }

        public HeaderCollection Headers { get; private set; }

        public CookieCollection Cookies { get; private set; }

        public string Body { get; private set; }

        public Session Session { get; private set; }

        public IReadOnlyDictionary<string, string> Form { get; private set; }

        public static Request Parse(string request)
        {
            var lines = request.Split("\r\n");
            var firstLine = lines.First()
                .Split(" ");

            var method = ParseMethod(firstLine[0]);
            var url = firstLine[1];
            var headers = ParseHeaders(lines.Skip(1));
            var cookies = ParseCookies(headers);
            var session = GetSession(cookies);
            var bodyLines = lines.Skip(headers.Count + 2);
            var body = string.Join("\r\n", bodyLines);
            var form = ParseForm(headers, body);

            return new Request()
            {
                Method = method,
                Url = url,
                Headers = headers,
                Cookies = cookies,
                Body = body,
                Session = session,
                Form = form
            };
        }
        private static Method ParseMethod(string method)
        {
            try
            {
                return Enum.Parse<Method>(method, true);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Method {method} is not supported.");
            }
        }

        private static HeaderCollection ParseHeaders(IEnumerable<string> lines)
        {
            var headerCollection = new HeaderCollection();

            foreach (var line in lines)
            {
                if (line == string.Empty)
                {
                    break;
                }

                var parts = line.Split(':', 2);

                if (parts.Length != 2)
                {
                    throw new InvalidOperationException("Request is not valid.");
                }

                headerCollection.Add(parts[0], parts[1].Trim());
            }

            return headerCollection;
        }
        
        private static CookieCollection ParseCookies(HeaderCollection headers)
        {
            var cookieCollection = new CookieCollection();

            if (headers.Contains(Header.Cookie))
            {
                var cookieHeader = headers[Header.Cookie];
                var allCookies = cookieHeader.Split(';');

                foreach (var cookie in allCookies)
                {
                    var cookieParts = cookie.Split('=');

                    var cookieName = cookieParts[0]?.Trim();
                    var cookieValue = cookieParts[1]?.Trim();

                    cookieCollection.Add(cookieName, cookieValue);
                }
            }

            return cookieCollection;
        }

        private static Session GetSession(CookieCollection cookies)
        {
            var sessionId = cookies.Contains(Session.SessionCookieName)
                ? cookies[Session.SessionCookieName]
                : Guid.NewGuid().ToString();
            
            if (!Sessions.ContainsKey(sessionId))
            {
                Sessions[sessionId] = new Session(sessionId);
            }

            return Sessions[sessionId];
        }

        private static Dictionary<string, string> ParseForm(HeaderCollection headers, string body)
        {
            var formCollection = new Dictionary<string, string>();

            if (headers.Contains(Header.ContentType)
                && headers[Header.ContentType] == ContentType.FormUrlEncoded)
            {
                var parsedResult = ParseFormData(body);

                foreach (var (name, value) in parsedResult)
                {
                    formCollection.Add(name, value);
                }
            }

            return formCollection;
        }

        private static Dictionary<string, string> ParseFormData(string body)
            => HttpUtility.UrlDecode(body)
            .Split('&')
            .Select(part => part.Split('='))
            .Where(part => part.Length == 2)
            .ToDictionary(
                part => part[0],
                part => part[1],
                StringComparer.InvariantCultureIgnoreCase);

    }
}
