using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace HttpListenerExample;
    class HttpServer
    {
        public static HttpListener? listener;
        public static string url = "http://localhost:8000/";
        public static int pageViews = 0;
        public static int requestCount = 0;
        public static string pageData =
            "<!DOCTYPE>" +
            "<html>" +
            "  <head>" +
            "    <title>HttpListener Example</title>" +
            "  </head>" +
            "  <body>" +
            "    <p>Page Views: {0}</p>" +
            "    <form method=\"post\" action=\"shutdown\">" +
            "      <input type=\"submit\" value=\"Shutdown\" {1}>" +
            "    </form>" +
            "  </body>" +
            "</html>";


        public static async Task HandleIncomingConnections()
        {
            bool runServer = true;

            // While a user hasn't visited the `shutdown` url, keep on handling requests
            while (runServer)
            {
                // Will wait here until we hear from a connection
                HttpListenerContext ctx = await listener!.GetContextAsync();

                // Peel out the requests and response objects
                HttpListenerRequest req = ctx.Request;
                HttpListenerResponse resp = ctx.Response;

                // Print out some info about the request
                Console.WriteLine("Request #: {0}", ++requestCount);
                Console.WriteLine(req.Url);
                Console.WriteLine(req.HttpMethod);
                Console.WriteLine(req.UserHostName);
                Console.WriteLine(req.UserAgent);
                Console.WriteLine();

                // If `shutdown` url requested w/ POST, then shutdown the server after serving the page
                if ((req.HttpMethod == "POST") && (req.Url!.AbsolutePath == "/shutdown"))
                {
                    Console.WriteLine("Shutdown requested");
                    runServer = false;
                }

                // Make sure we don't increment the page views counter if `favicon.ico` is requested
                if (req.Url!.AbsolutePath != "/favicon.ico")
                    pageViews += 1;

                // Write the response info
                string disableSubmit = !runServer ? "disabled" : "";
                byte[] data = Encoding.UTF8.GetBytes(String.Format(pageData, pageViews, disableSubmit));
                resp.ContentType = "text/html";
                resp.ContentEncoding = Encoding.UTF8;
                resp.ContentLength64 = data.LongLength;

                // Write out to the response stream (asynchronously), then close it
                await resp.OutputStream.WriteAsync(data, 0, data.Length);
                resp.Close();
            }
        }
    }
class WebSocket
{
    public static async Task WebSocketOn()
    {
        TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
        server.Start();
        Console.WriteLine("Server gestart op 127.0.0.1:8080. Wacht op verbinding...");

        TcpClient client = await server.AcceptTcpClientAsync();
        Console.WriteLine("Een client verbonden.");

        NetworkStream stream = client.GetStream();

        byte[] buffer = new byte[1024];
        int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
        string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        Console.WriteLine("Ontvangen bericht: " + request);

        string response = "Hallo, wereld!";
        byte[] data = Encoding.UTF8.GetBytes(response);

        await stream.WriteAsync(data, 0, data.Length);
        Console.WriteLine("Verzonden bericht: " + response);

        client.Close();
        server.Stop();
    }
}

class Program
{
    static void Main(string[] args)
    {
        WebSocket.WebSocketOn().GetAwaiter().GetResult();
        // Create a Http server and start listening for incoming connections
        HttpServer.listener = new HttpListener();
        HttpServer.listener.Prefixes.Add(HttpServer.url);
        HttpServer.listener.Start();
        Console.WriteLine("Listening for connections on {0}", HttpServer.url);

        // Handle requests
        Task listenTask = HttpServer.HandleIncomingConnections();
        listenTask.GetAwaiter().GetResult();

        // Close the listener
        HttpServer.listener.Close();

        // Start the WebSocket
    }
}