
using System;
using System.Linq;
using Models;
using DataModel;
using System.Net.Mail;
using System.Text;

namespace BusinessLogic
{
    public class ProblemsBusinessLogic : BaseBusinessLogic
    {
        public override object Get(string id)
        {
            object obj;
            try
            {
                using (var db = new PFEDatabaseEntities())
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

        public override object Add(object obj, string ProbId)
        {
            ProblemsDTO prob = (ProblemsDTO)obj;
            try
            {
                using (var db = new PFEDatabaseEntities())
                {
                    //var result = db.Problems.FirstOrDefault(c => c.ProblemId == prob.ProblemId);
                    //if (!obj.Equals(result))
                    db.Problems.Add(new Problems()
                    {
                        DateProb = prob.DateProb,//TODO on mets la date nous même  ? 
                        Fixed = false,
                        MachineId = db.Machines.Where(m => m.MachineId == prob.MachineId).First().MachineId,
                        UserId = db.Users.Where(u => u.UserId == prob.UserId).First().UserId,
                        Photo = prob.Photo,
                        ProbDescription = prob.ProbDescription,
                        Statut = prob.Statut
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
            ProblemsDTO prob = (ProblemsDTO)obj;
            try
            {
                using (var db = new PFEDatabaseEntities())
                {
                    if (db.Problems.Where(p => p.ProblemId == prob.ProblemId).Count() == 0)
                        return;

                    db.Problems.Remove(db.Problems.First(p => p.ProblemId == prob.ProblemId));

                    db.SaveChanges();


                    db.Problems.Add(new Problems()
                    {
                        DateProb = DateTime.Now,//TODO on mets la date nous même  ? 
                        Fixed = false,
                        MachineId = db.Machines.Where(m => m.MachineId == prob.MachineId).First().MachineId,
                        UserId = db.Users.Where(u => u.UserId == prob.UserId).First().UserId,
                        Photo = prob.Photo,
                        ProbDescription = prob.ProbDescription,
                        Statut = prob.Statut
                    });
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
            ProblemsDTO prob = (ProblemsDTO)obj;

            try
            {
                using (var db = new PFEDatabaseEntities())
                {
                    if (db.Problems.Where(p => p.ProblemId == prob.ProblemId).Count() == 0)
                        return;

                    db.Problems.Remove(db.Problems.First(p => p.ProblemId == prob.ProblemId));

                    db.SaveChanges();

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void SendMail(string message)
        {

            // Command line argument must the the SMTP host.
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("fakerage702@gmail.com", "plelatlirce");

            MailMessage mm = new MailMessage("donotreply@domain.com", "fakerage702@gmail.com", message , message );
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);
        }

        public void Dispose()
        {

        }

    }
}
