
using System;
using System.Linq;
using Models;
using DataModel;
using System.Collections.Generic;
using static DataMapper.DatabaseMapper;
using System.Collections;
using System.Data.Entity;
using System.Data.Linq;

namespace BusinessLogic
{
    public class MachinesBusinessLogic : BaseBusinessLogic
    {
        //private  PFEDatabaseEntities db; 
        //public MachinesBusinessLogic(PFEDatabaseEntities dbx)
        //{
        //    this.db = dbx;
        //}

        private object GetAll()
        {
            List<Machines> result = null;
            try
            {
                using (var db = new PFEDatabaseEntities())
                {

                    result = db.Machines.ToList();
                    string text = result.ToString();

                    Console.WriteLine(text);

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return MapToMachinesDTO(result);
        }

        public override object Get(string id)
        {

            int machineId = 0;
            List<Machines> result = null;

            // GETS ALL THE MACHINES IF ID == 0
            if (id == "0")
            {
                return GetAll();
            }

            if (!Int32.TryParse(id, out machineId))
            {
                try
                {
                    using (var db = new PFEDatabaseEntities())
                    {
                        result = db.Machines.Where(c => c.MachineId == machineId).ToList();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
            {
                try
                {
                    using (var db = new PFEDatabaseEntities())
                    {
                        result = db.Machines.Where(c => c.MachineId == machineId).ToList();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            return MapToMachinesDTO(result);
        }

        public override object Add(object obj, string id)
        {
            List<MachinesDTO>
                machines = (List<MachinesDTO>)obj;
            

            // int integerId = Int32.Parse(id);
            string message = "";
            string text = obj.ToString() + " \t ";
            Console.WriteLine(text);
            try
            {

                using (var db = new PFEDatabaseEntities())
                {
                    foreach (MachinesDTO machine in machines)
                    {

                        if (db.Machines.Where(cont => cont.MachineName == machine.MachineName).Count() > 0)
                        {
                            message += machine.MachineName + "existe déjà \t";
                            Console.WriteLine(text);

                            return message;
                        }

                        if (db.Machines.Where(cont => cont.MacAddress == machine.MacAddress).Count() > 0)
                        {
                            message += machine.MacAddress + "existe déjà  adress invalide \t";
                            return message;
                        }

                        db.Machines.Add(
                            new Machines()
                            {
                                MachineName = machine.MachineName,
                                MacAddress = machine.MacAddress,
                                Comment = machine.Comment,
                                Statut = machine.Statut,
                                local = machine.local,
                                IpAddress = machine.IpAddress
                            }
                    );
                    }

                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return e.Message + e.StackTrace;
            }
            return message;
        }

        public override void Modify(object obj, string userId)
        {
            MachinesDTO machine = (MachinesDTO)obj;
            //int integerId = Int32.Parse(userId);
            try
            {
                using (var db = new PFEDatabaseEntities())
                {
                    if (db.Machines.Where(w => w.MachineName == machine.MachineName).Count() == 0)
                        return;
                    Machines m = db.Machines.First(contr => contr.MachineName == machine.MachineName);
                    m.MachineName = machine.MachineName;
                    m.MacAddress = machine.MacAddress;
                    m.Comment = machine.Comment;
                    m.Statut = machine.Statut;
                    m.local = machine.local;

                    //db.Machines.Remove(db.Machines.First(contr => contr.MachineName == machine.MachineName));

                    db.SaveChanges();

                    //db.Machines.Add(new Machines()
                    //{
                    //    MachineName = machine.MachineName,
                    //    MacAddress = machine.MacAddress,
                    //    Comment = machine.Comment,
                    //    Statut = machine.Statut,
                    //    local = machine.local
                    //});

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override void Remove(object obj)
        {
            MachinesDTO machine = (MachinesDTO)obj;
            try
            {
                using (var db = new PFEDatabaseEntities())
                {
                    db.Machines.Remove(db.Machines.First(m => m.MachineName == machine.MachineName));
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
