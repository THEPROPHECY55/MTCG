using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace MTCG.Networking
{
    public class HttpServer
    {
        private readonly IPAddress _host;   // server IP adress
        private readonly int _port;         // server port
        private TcpListener _listener;      // accept incoming connections

        // initialize server with host IP + port
        public HttpServer(IPAddress host, int port)
        {
            _host = host;
            _port = port;
        }

        // start server + begin listening for connections
        public void Start()
        {
            _listener = new TcpListener(_host, _port); // initialize TCP listener
            _listener.Start(); // accept incoming connections
            Console.WriteLine($"[SERVER] Server running at {_host}:{_port}");

            while (true)
            {
                var client = _listener.AcceptTcpClient(); // accept incoming TCP client connection
                
                // create new thread for handle client connection (server responsive)
                var clientThread = new Thread(() => HandleClient(client));
                clientThread.Start();
            }
        }

        // handle communication with connected client
        private void HandleClient(TcpClient client)
        {
            var stream = client.GetStream(); // get network stream for reading/writing data
            var buffer = new byte[1024];     // to store received data

            // read data from client into buffer + get byte count
            var byteCount = stream.Read(buffer, 0, buffer.Length);

            // convert byte array into string
            var requestString = Encoding.UTF8.GetString(buffer, 0, byteCount);

            // parse raw request string into HttpRequest object
            var request = HttpRequest.Parse(requestString);

            // route request using Router + generate HttpResponse
            HttpResponse response = Router.Route(request);

            // convert HttpResponse object into bytes
            byte[] responseBytes = Encoding.UTF8.GetBytes(response.ToString());
            stream.Write(responseBytes, 0, responseBytes.Length); // send response to client

            stream.Close();
            client.Close();
        }
    }
}