using System;
using Newtonsoft.Json; // wegen .net v3.5 JSON serialization
using MTCG.UserCore;

namespace MTCG.Networking
{
    public static class AuthController
    {
        // handle user registration requests
        public static HttpResponse Register(HttpRequest request)
        {
            try
            {
                Console.WriteLine(request.Body); // Debug: print body
                // deserialize request body into UserDTO object
                var data = JsonConvert.DeserializeObject<UserDTO>(request.Body);
                
                // call service for user register, return true if successful
                if (UserService.RegisterUser(data.Username, data.Password))
                {
                    return new HttpResponse
                    {
                        StatusCode = 200,
                        ContentType = "application/json",
                        Body = "{\"message\":\"User registered successfully\"}"
                    };
                }
                else
                {
                    return new HttpResponse
                    {
                        StatusCode = 400,
                        ContentType = "application/json",
                        Body = "{\"message\":\"Username already exists\"}"
                    };
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.StackTrace); // Debug
                return new HttpResponse
                {
                    StatusCode = 400,
                    ContentType = "application/json",
                    Body = "{\"message\":\"Bad Request\"}"
                };
            }
        }

        // handle user login requests
        public static HttpResponse Login(HttpRequest request)
        {
            try
            {
                var data = JsonConvert.DeserializeObject<User>(request.Body);
                
                // log in user + retrieve token if successful
                var token = UserService.LoginUser(data.Username, data.Password);

                if (token != null)
                {
                    // if login successful return 200 status + token
                    return new HttpResponse
                    {
                        StatusCode = 200,
                        ContentType = "application/json",
                        Body = $"{{\"token\":\"{token}\"}}"
                    };
                }
                else
                {
                    // if login invalid
                    return new HttpResponse
                    {
                        StatusCode = 401,
                        ContentType = "application/json",
                        Body = "{\"message\":\"Invalid credentials\"}"
                    };
                }
            }
            catch (Exception)
            {
                return new HttpResponse
                {
                    StatusCode = 400,
                    ContentType = "application/json",
                    Body = "{\"message\":\"Bad Request\"}"
                };
            }
        }
    }
}
