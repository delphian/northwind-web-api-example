using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Northwind.API
{
    public interface IJwtManager
    {
        /**
         * Create a JSON web token.
         */
        string GenerateToken(string username, int expireMinutes = 30);
        /**
         * Construct the Principal (user) object.
         */
        ClaimsPrincipal GetPrincipal(string token);
    }
}