
using System;
using Models;
using System.Collections.Generic;
using QRCoder;
using iTextSharp.text;
using System.IO;
using System.Net.Http;
using iTextSharp.text.pdf;
using System.Net;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Net.Http.Headers;
using DataModel;

namespace BusinessLogic
{
    public class QrCodeBusinessLogic : BaseBusinessLogic
    {

        public override object Get(string id)
        {
            // local017
            // 0
            // machine 

            BaseBusinessLogic mBiz = new MachinesBusinessLogic();
            List<MachinesDTO> machines = (List<MachinesDTO>)mBiz.Get("0");

            if (id.StartsWith("local"))
            {
                machines = machines.FindAll(w => w.local == id.Substring(5));
            }
            else if (id != "0")
            {
                machines = machines.FindAll(w => w.MachineName == id);
            }

            Document doc = new Document(PageSize.A4);
            MemoryStream workStream = new MemoryStream();
            int i = 0;
            PdfWriter.GetInstance(doc, workStream);
            doc.Open();
            doc.Add(new Paragraph("aight"));
            string url = "https://stormy-dawn-50375.herokuapp.com/report/";
            
            foreach (MachinesDTO m in machines)
            {
                BarcodeQRCode barcodeQRCode = new BarcodeQRCode(url + m.MachineName, 144, 144, null);
                var pdfImg = barcodeQRCode.GetImage();
                doc.Add(new Paragraph(m.MachineName));
                doc.Add(pdfImg);
                if (i % 3 == 0 && i != 0)
                    doc.NewPage();
                i++;
            }
            
            doc.Close();

            byte[] pdf = workStream.ToArray();
            String base64 = Convert.ToBase64String(pdf);
            /*HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(pdf);
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline");
            result.Content.Headers.ContentDisposition.FileName = "MyPdf.pdf";
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
    */        
    return "data:application/pdf;base64," + base64;
            //return ;
        }


        public virtual object Add(object obj, string id)
        {
            throw new Exception("Not implemented for this object");
        }

        public virtual object Modify(object obj, string id)
        {
            throw new Exception("Not implemented for this object");
        }

        public virtual object Remove(object obj)
        {
            throw new Exception("Not implemented for this object");
        }


        public void Dispose()
        {

        }
    }

}