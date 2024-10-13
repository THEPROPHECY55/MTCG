using System;

namespace MTCG.UserCore
{
    public static class TokenManager
    {
        public static string GenerateToken(string username)
        {
            return $"{username}-{Guid.NewGuid()}"; // Globally Unique Identifier
        }
    }
}