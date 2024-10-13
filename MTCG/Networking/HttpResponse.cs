using System;
using System.Text;

namespace MTCG.Networking
{
    public class HttpResponse
    {
        public int StatusCode { get; set; }
        public string ContentType { get; set; }
        public string Body { get; set; }

        // converts HttpResponse object into formatted HTTP response string
        public override string ToString()
        {
            StringBuilder responseBuilder = new StringBuilder();
            
            responseBuilder.AppendLine($"HTTP/1.1 {StatusCode} {GetStatusMessage(StatusCode)}");
            responseBuilder.AppendLine($"Content-Type: {ContentType}");
            responseBuilder.AppendLine("Connection: close");
            responseBuilder.AppendLine();
            responseBuilder.AppendLine(Body);

            return responseBuilder.ToString(); // string
        }

        private string GetStatusMessage(int statusCode)
        {
            return statusCode switch
            {
                200 => "OK",                     // success
                400 => "Bad Request",            // malformed request
                401 => "Unauthorized",           // authentication required or failed
                404 => "Not Found",              // resource not found
                500 => "Internal Server Error",  // server-side issue
                _ => "Unknown StatusCode"
            };
        }
    }
}