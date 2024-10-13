using System;
using System.Collections.Generic;
using System.Linq;

namespace MTCG.Networking
{
    public class HttpRequest
    {
        public string Method { get; private set; }
        public string Path { get; private set; }
        public Dictionary<string, string> Headers { get; private set; } = new Dictionary<string, string>();
        public string Body { get; private set; }

        // parse raw HTTP request string into HttpRequest object
        public static HttpRequest Parse(string requestString)
        {
            // split incoming HTTP request string by CRLF (return + new line)
            var lines = requestString.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            
            // first line of HTTP request is request line
            var requestLine = lines[0].Split(' ');

            // create new HttpRequest object, setting Method + Path from request line
            var request = new HttpRequest
            {
                Method = requestLine[0], // GET, POST...
                Path = requestLine[1] // request path
            };

            int lineIndex = 1;
            
            // parse headers (zeilen between request zeile and empty zeile)
            // header format: "Header-Name: Header-Value"
            while (!string.IsNullOrEmpty(lines[lineIndex]))
            {
                var headerLine = lines[lineIndex].Split(new string[] { ": " }, StringSplitOptions.None);
                request.Headers[headerLine[0]] = headerLine[1]; // add parsed header to Headers dictionary
                lineIndex++;
            }

            // skip empty line after headers
            lineIndex++;

            // extract body + join all remaning lines as body, separated by CRLF
            request.Body = string.Join("\r\n", lines.Skip(lineIndex).ToArray());

            return request;
        }

    }
}