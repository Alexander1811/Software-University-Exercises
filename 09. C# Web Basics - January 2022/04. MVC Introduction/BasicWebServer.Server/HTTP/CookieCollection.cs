namespace BasicWebServer.Server.HTTP
{
    using System.Collections;
    using System.Collections.Generic;

    public class CookieCollection : IEnumerable<Cookie>
    {
        private readonly Dictionary<string, Cookie> cookie;

        public CookieCollection()
            => this.cookie = new Dictionary<string, Cookie>();

        public string this[string name]
            => this.cookie[name].Value;

        public void Add(string name, string value)
            => this.cookie[name] = new Cookie(name, value);

        public bool Contains(string name) 
            => this.cookie.ContainsKey(name);

        public IEnumerator<Cookie> GetEnumerator() 
            => this.cookie.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() 
            => this.GetEnumerator();
    }
}
