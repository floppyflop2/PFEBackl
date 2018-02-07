
using System;
using System.Linq;
using Models;
using DataModel;
using System.Collections.Generic;
using static DataMapper.DatabaseMapper;
using QRCoder;
using iTextSharp.text;
using System.IO;
using System.Drawing;

namespace BusinessLogic
{
    public class QrCodeBusinessLogic : BaseBusinessLogic
    {
        
        public object Get(string id)
        {
            BaseBusinessLogic mBiz = new MachinesBusinessLogic();
            List<MachinesDTO> machines = (List<MachinesDTO>)mBiz.Get(id);
            Document doc = new Document(PageSize.A4);
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            MemoryStream workStream = new MemoryStream();
            int i = 0;

            doc.Open();
            foreach(MachinesDTO m in machines)
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
            doc.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;

            return FileResult(workStream, "application/pdf" , "qr_machines.pdf");
    }
}
