using Service.Models;
using System.Web.Http;
using Operations;

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
    }

    internal class Users
    {
        public Users()
        {
        }

        public string AspNetUserId { get; set; }
        public string UserEmail { get; set; }
    }
}