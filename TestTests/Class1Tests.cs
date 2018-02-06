using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using DataModel;
using Models;
using QRCoder;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace Test.Tests
{
    [TestClass()]
    public class Class1Tests
    {

        [TestMethod()]
        public void mainTest()
        {

         

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