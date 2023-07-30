using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiStringArray.Controllers
{
    public class NamesApiController : ApiController
    {
        string[] names = {"Tejesh","Ramesh","Samantha" };

        public string[] GetEmp()
        {
            return names;
        }

        public string GetEmp(int id )
        {
            return names[id];
        }
    }
}
