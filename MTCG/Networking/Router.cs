using System;

namespace MTCG.Networking
{
    public static class Router
    {
        public static HttpResponse Route(HttpRequest request)
        {
            if (request.Method == "POST" && request.Path == "/login")
            {
                return AuthController.Login(request);
            }
            else if (request.Method == "POST" && request.Path == "/register")
            {
                return AuthController.Register(request);
            }
            else
            {
                return new HttpResponse
                {
                    StatusCode = 404,
                    ContentType = "application/json",
                    Body = "{\"message\":\"Not Found (404)\"}"
                };
            }
        }
    }
}