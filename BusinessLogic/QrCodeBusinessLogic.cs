
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
                machines = machines.FindAll(w => w.local == id.Substring(4));
            }
            else if (id != "0")
            {
                machines = machines.FindAll(w => w.MachineName == id);
            }

            Document doc = new Document(PageSize.A4);
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            MemoryStream workStream = new MemoryStream();
            int i = 0;
            PdfWriter.GetInstance(doc, workStream).CloseStream = false;
            doc.Open();
            foreach (MachinesDTO m in machines)
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(m.MachineName, QRCodeGenerator.ECCLevel.Q);
                QRCode qrcode = new QRCode(qrCodeData);
                System.Drawing.Image img = qrcode.GetGraphic(20);
                iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(img, System.Drawing.Imaging.ImageFormat.Jpeg);
                pdfImage.ScalePercent(25);
                doc.Add(new Paragraph(m.MachineName));
                doc.Add(pdfImage);
                if (i % 3 == 0 && i != 0)
                    doc.NewPage();
                i++;
            }

            byte[] byteInfo = workStream.ToArray();

            doc.Close();





            //IHttpActionResult response;
            //HttpResponseMessage responseMsg = new HttpResponseMessage(HttpStatusCode.OK);
            //responseMsg.Content = new ByteArrayContent(byteInfo);
            //responseMsg.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            //responseMsg.Content.Headers.ContentDisposition.FileName = "etst.pdf";
            //responseMsg.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            //response = ResponseMessage(responseMsg);
            //return response;
            return null;
        }


        public virtual object Add(object obj, string id)
        {
            throw new Exception("Not implemented for this object");
        }

        public virtual void Modify(object obj, string id)
        {
            throw new Exception("Not implemented for this object");
        }

        public virtual void Remove(object obj)
        {
            throw new Exception("Not implemented for this object");
        }


        public void Dispose()
        {

        }
    }

}