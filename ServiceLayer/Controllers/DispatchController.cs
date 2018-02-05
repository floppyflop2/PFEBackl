using Service.Models;
using System.Web.Http;
using Operations;
using DataModel;

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
            //return null;

        }

        [HttpGet]
        [Route("Get")]
        public object Get(string name)
        {
            Users a = new Users()
            {
                UserEmail = "aaaaa",
                AspNetUserId = "aaaaaaaa"
            };
            //  return name == null ? "Give a name" : Operation.Get(name, User.Identity.GetUserId());
            return a;
            //return null;

        }

        [HttpPut]
        [Route("{name}")]
        public object DispatchPut(RequestModel obj, string name)
        {
            if (name == null)
                return "Give a name";
            //   Operation.Modify(name, obj.FindCorrectDTO(), User.Identity.GetUserId());
            return "";
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("{name}/{id}")]
        public object DispatchGet(string name, string id)
        {
            return name == null ? "Give a name" : Operation.Get(name, id);
        }

     
        [HttpPost]
        [Route("{name}")]
        public object DispatchPost(RequestModel obj, string name)
        {
            //   return name == null ? "Give a name" : Operation.Add(name, obj.FindCorrectDTO(), User.Identity.GetUserId());
            return null;
        }



        [Authorize(Roles = "Admin")]
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