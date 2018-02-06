
using System;
using System.Linq;
using Models;
using DataModel;
using System.Collections.Generic;
using static DataMapper.DatabaseMapper;

namespace BusinessLogic
{
    public class UserBusinessLogic : BaseBusinessLogic
    {
        public override object Get(string id)
        {

            List<UserDTO> result;
            if (id == "0")
            {
                return GetAll();
            }

            try
            {
                using (var db = new PFEDatabaseEntities())
                {
                    result = MapToUserDTO(db.Users.Where(u => u.AspNetUserId == id).ToList());
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }

        public object GetAll()
        {
            List<UserDTO> result;
            try
            {
                using (var db = new PFEDatabaseEntities())
                {
                    result = MapToUserDTO(db.Users.ToList());
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }

        public override object Add(object obj, string userId)
        {
            UserDTO usr = (UserDTO)obj;
            try
            {
                using (var db = new PFEDatabaseEntities())
                {
                    var result = db.Users.FirstOrDefault(c => c.UserEmail == usr.UserEmail);
                    if (!obj.Equals(result))
                        db.Users.Add(new Users()
                        {
                            UserEmail = usr.UserEmail,
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
            UserDTO user = (UserDTO)obj;

            try
            {
                using (var db = new PFEDatabaseEntities())
                {
                    Users usr = db.Users.First(w => w.AspNetUserId == id);
                    usr.UserEmail = user.UserEmail;
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override void Remove(object obj)
        {
            UserDTO usr = (UserDTO)obj;
            try
            {
                using (var db = new PFEDatabaseEntities())
                {
                    db.Users.Remove(db.Users.First(cont => cont.ContractId == usr.UserId));
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public void Dispose()
        {

        }

    }
}
