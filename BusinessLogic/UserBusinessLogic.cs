
using System;
using System.Linq;
using Models;
using DataModel;

namespace BusinessLogic
{
    public class UserBusinessLogic : BaseBusinessLogic
    {
        public override object Get(string id)
        {
            object obj;
            try
            {
                using(var db = new PFEDatabaseEntities())
                {
                    obj = db.Users.First();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return obj;
        }

        public override object Add(object obj, string userId)
        {
            UserDTO usr = (UserDTO)obj;
            try
            {
                using (var db = new PFEDatabaseEntities())
                {
                    var result = db.Users.FirstOrDefault(c => c.UserEmail == usr.Email);
                    if (!obj.Equals(result))
                        db.Users.Add(new Users()
                        {
                            UserEmail = usr.Email,
                            AspNetUserId = userId
                        });
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return "";
        }

        public override void Modify(object obj, string id)
        {
            throw new Exception("Not implemented for this object");
        }

        public override void Remove(object obj)
        {
            throw new Exception("Not implemented for this object");
        }


        public void Dispose()
        {

        }

    }
}
