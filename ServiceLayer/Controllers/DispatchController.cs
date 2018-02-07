using Service.Models;
using System.Web.Http;
using Operations;
using DataModel;
using Models;
using Microsoft.AspNet.Identity;

namespace ServiceLayer.Controllers
{
    public class DispatchController : ApiController
    {

        [HttpGet]
        [Route("{name}")]
        public object DispatchGet(string name)
        {
            //  return name == null ? "Give a name" : Operation.Get(name, User.Identity.GetUserId());
            return name == null ? "Give a name" : Operation.Get(name, "");
        }


        [HttpPut]
        [Route("{name}")]
        public object DispatchPut(RequestModel obj, string name)
        {
            if (name == null)
                return "Give a name";
            Operation.Modify(name, obj.FindCorrectDTO(), User.Identity.GetUserId());
            //Operation.Modify(name, obj.FindCorrectDTO(), "");
            return "";
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        [Route("{name}/{id}")]
        public object DispatchGet(string name, string id)
        {
            var result = name == null ? "Give a name" : Operation.Get(name, id);
            return result;
        }


        [HttpPost]
        [Route("{name}")]
        public object DispatchPost(RequestModel obj, string name)
        {
          //  return name == null ? "Give a name" : Operation.Add(name, obj.FindCorrectDTO(), User.Identity.GetUserId());
          return name == null ? "Give a name" : Operation.Add(name, obj.FindCorrectDTO(), "");
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{name}")]
        public object DispatchDelete(RequestModel obj, string name)
        {
            if (name == null)
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