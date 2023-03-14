using System;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace Server
{
    class HttpServer
    {
        private static HttpListener listener;
        private static string url = "http://localhost:8080/";
        private static int pageViews = 0;
        private static int requestCount = 0;

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
            var running = true;
            
            while (running)
            {
                var context = await listener.GetContextAsync();

                var request = context.Request;

                PrintRequestData(request);
                
                if ((request.HttpMethod == "POST") && (request.Url.AbsolutePath == "/shutdown"))
                {
                    Console.WriteLine("Shutdown requested");
                    running = false;
                }
                
                if (request.Url.AbsolutePath != "/favicon.ico")
                    pageViews += 1;

                var disableSubmit = !running ? "disabled" : "";
                var data = Encoding.UTF8.GetBytes(String.Format(pageData, pageViews, disableSubmit));
                
                var response = FormResponse(context, data);
                
                await response.OutputStream.WriteAsync(data, 0, data.Length);
                response.Close();
            }
        }

        private static void PrintRequestData(HttpListenerRequest request)
        {
            Console.WriteLine("Request #: {0}", ++requestCount);
            Console.WriteLine(request.Url.ToString());
            Console.WriteLine(request.HttpMethod);
            Console.WriteLine(request.UserHostName);
            Console.WriteLine(request.UserAgent);
            Console.WriteLine();
        }

        private static HttpListenerResponse FormResponse(HttpListenerContext context, byte[] data)
        {
            var response = context.Response;
            response.ContentType = "text/html";
            response.ContentEncoding = Encoding.UTF8;
            response.ContentLength64 = data.LongLength;

            return response;
        }
    }
}