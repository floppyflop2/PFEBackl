using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using DataModel;
using Models;
using iTextSharp.text;
using QRCoder;
using System.Drawing;
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
            Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\Florian\\Documents\\Visual Studio 2015\\Projects\\PFEBack\\image2.pdf", FileMode.Create));
            doc.Open();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            string[] tab = { "zizi", "tout", "dur" };
            Bitmap[] imgTab = new Bitmap[3];
            int i = 0;
            foreach (string s in tab)
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(s, QRCodeGenerator.ECCLevel.Q);
                QRCode qrcode = new QRCode(qrCodeData);
                Bitmap qrCodeImg = qrcode.GetGraphic(20);
                imgTab[i++] = qrCodeImg;
                System.Drawing.Image image = imgTab[i];
                iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Jpeg);
                doc.Add(pdfImage);
            }

            doc.Close();
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