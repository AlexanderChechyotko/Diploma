using EasyKatka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EasyKatka.Controllers
{
    public class AuthenticationApiController : ApiController
    {
        [HttpGet]
        public User LogIn()
        {
            var user = new User
            {
                Name = "Alexander"
            };

            return user;
        }
    }
}
