using iTextSharp.text.pdf;
using QRCoder;
using System.IO;
using System.Web;
using System.Xml.Linq;
using System.Drawing;
using iTextSharp.text;

namespace Utils
{
    public class QRCodeRead
    {

        public void QRGen(string name, string location )
        {
       
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("The text which should be encoded.", QRCodeGenerator.ECCLevel.Q);
            System.Drawing.Image image = System.Drawing.Image.FromFile("Your image file path");
            Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\Florian\\Documents\\Visual Studio 2015\\Projects\\PFEBack\\image2.pdf", FileMode.Create));
            doc.Open();
            iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Jpeg);
            doc.Add(pdfImage);
            doc.Close();

        }
    }

   
}
