using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using DataModel;
using Models;

namespace Test.Tests
{
    [TestClass()]
    public class Class1Tests
    {
        [TestMethod()]
        public void mainTest()
        {
            using (var db = new PFEDatabaseEntities())
            {
                db.Users.Add(new Users()
                {
                    UserEmail = "aaaaa",
                    AspNetUserId = "aaaaaaaa"
                });
                db.SaveChanges();

            }

        }

        [TestMethod()]
        public void UserGetTest()
        {
            using (var db = new PFEDatabaseEntities())
            {
                UserDTO usr = DataMapper.DatabaseMapper.MapToUserDTO(db.Users.First());

                Console.WriteLine(usr.UserEmail);

            }

        }


    }

}