namespace BasicWebServer.Server
{
    using BasicWebServer.Server.HTTP;
    using BasicWebServer.Server.Routing;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListener;

        private readonly RoutingTable routingTable;

        public HttpServer(
            string ipAddress,
            int port,
            Action<IRoutingTable> routingTableConfiguration)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;

            this.serverListener = new TcpListener(this.ipAddress, this.port);

            routingTableConfiguration(this.routingTable = new RoutingTable());
        }

        public HttpServer(int port, Action<IRoutingTable> routingTable)
            : this("127.0.0.1", port, routingTable) { }

        public HttpServer(Action<IRoutingTable> routingTable)
            : this(8080, routingTable) { }

        public void Start()
        {
            this.serverListener.Start();

            Console.WriteLine($"Server started on port {this.port}");
            Console.WriteLine("Listening for requests...");

            while (true)
            {
                var connection = this.serverListener.AcceptTcpClient();
                var networkStream = connection.GetStream();

                var requestText = this.ReadRequest(networkStream);
                Console.WriteLine(requestText);
                var request = Request.Parse(requestText);

                var response = this.routingTable.MatchRequest(request);

                if (response.PreRenderAction != null)
                {
                    response.PreRenderAction(request, response);
                }

                this.WriteResponse(networkStream, response);

                connection.Close();
            }
        }

        private void WriteResponse(NetworkStream networkStream, Response response)
        {
            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());

            networkStream.Write(responseBytes);
        }

        private string ReadRequest(NetworkStream networkStream)
        {
            var buffer = new byte[1024];
            var totalBytes = 0;

            var request = new StringBuilder();

            do
            {
                var bytesRead = networkStream.Read(buffer, 0, buffer.Length);
                totalBytes += bytesRead;

                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is too large.");
                }

                request.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }
            while (networkStream.DataAvailable);

            return request.ToString();
        }
    }
}
