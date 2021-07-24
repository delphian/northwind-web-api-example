using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Northwind.API.Controllers
{
    public class TokenController : ApiController
    {
        private readonly IJwtManager jwtManager;
        /**
         * Constructor for dependency injection.
         */
        public TokenController(IJwtManager jwtManager)
        {
            this.jwtManager = jwtManager;
        }
        [AllowAnonymous]
        public string Get(string username, string password)
        {
            if (CheckUser(username, password))
            {
                return jwtManager.GenerateToken(username);
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        public bool CheckUser(string username, string password)
        {
            // Uber security; this is.
            return true;
        }
    }
}