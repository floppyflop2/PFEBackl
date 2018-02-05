using Service.Models;
using Newtonsoft.Json;
using Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Service
{
    [Authorize]
    public class DispatchController : ApiController
    {

        [HttpGet]
     //   [Authorize(Roles = "Admin")]
        [Route("{name}/{id}")]
        public object DispatchGet(string name, string id)
        {
            return name == null ? "Give a name" : Operation.Get(name, id);
        }

        [HttpGet]
        [Route("{name}")]
        public object DispatchGet(string name)
        {
            return name == null ? "Give a name" : Operation.Get(name, User.Identity.GetUserId());
        }

        [HttpPost]
        [Route("{name}")]
        public object DispatchPost(RequestModel obj, string name)
        {
            return name == null ? "Give a name" : Operation.Add(name, obj.FindCorrectDTO(), User.Identity.GetUserId());
        }

        
        [HttpPut]
        [Route("{name}")]
        public object DispatchPut(RequestModel obj, string name)
        {
            if (name == null)
                return "Give a name";
            Operation.Modify(name, obj.FindCorrectDTO(), User.Identity.GetUserId());
            return "";
        }

  //      [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{name}")]
        public object DispatchDelete(RequestModel obj, string name)
        {
            if  (name == null)
                return "Give a name";
            Operation.Remove(name, obj.FindCorrectDTO());
            return "";
        }
        

        [HttpGet]
        [Route("Admin")]
        public bool DispatchRole()
        {
            return User.IsInRole("Admin");
        }
    }
}
