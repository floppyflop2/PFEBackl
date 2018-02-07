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
            /**/
  //          MemoryStream memStream = new MemoryStream();
//            PdfWriter wri = PdfWriter.GetInstance(doc, memStream);
            Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\fmorel15\\Source\\Repos\\PFEBack\\img.pdf", FileMode.OpenOrCreate));
            doc.Open();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            string[] tab = { "http://facebook.com", "tout ", "tout ", "tout ", "dur " };
            Bitmap[] imgTab = new Bitmap[5];
            int i = 0;

            foreach (string s in tab)
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(s, QRCodeGenerator.ECCLevel.Q);
                QRCode qrcode = new QRCode(qrCodeData);
                Bitmap qrCodeImg = qrcode.GetGraphic(20);
                imgTab[i] = qrCodeImg;
                System.Drawing.Image image = imgTab[i];
                iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Jpeg);
                pdfImage.ScalePercent(25);
                doc.Add(new Paragraph(tab[i]));
                doc.Add(pdfImage);
                if (i % 3 == 0 && i != 0)
                    doc.NewPage();
                i++;
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