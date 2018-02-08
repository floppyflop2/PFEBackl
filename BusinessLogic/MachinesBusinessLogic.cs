
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
                        result = db.Machines.Where(c => c.MachineName == id).ToList();
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
           
            string loc = machines.First().local;

            try
            {

                using (var db = new PFEDatabaseEntities())
                {
                    if(db.Machines.Count() != 0)
                    {
                        List<Machines> allMach = db.Machines.Where(m => m.local == loc).ToList();
                        var result = allMach.Where(m => machines.All(m2 => m2.MachineName != m.MachineName));
                        List<Machines> inactiveMach = result.ToList();

                        foreach (Machines machine in inactiveMach)
                        {
                            machine.Statut = "inactive";
                        }
                        db.SaveChanges();
                    }
                  

                    foreach (MachinesDTO machine in machines)
                    {
                        if (db.Machines.Count() != 0)
                        {
                            Machines activate = db.Machines.Where(cont => cont.MachineName == machine.MachineName).First();
                            if (activate != null)
                            {
                             //   message += activate.MachineName + "existe déjà \t";
                                activate.Statut = "active";
                                db.SaveChanges();
                                continue;
                            }

                            if (db.Machines.Where(cont => cont.MacAddress == machine.MacAddress).Count() > 0)
                            {
                                message += machine.MacAddress + machine.MacAddress + "existe déjà  adress invalide \t";
                                continue;
                            }
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

                    message += "add Machines succeeded";
                }
            }
            catch (Exception e)
            {
                return e.Message + e.StackTrace;
            }
            return message;
        }

        public override object Modify(object obj, string userId)
        {
            MachinesDTO machine = (MachinesDTO)obj;
            //int integerId = Int32.Parse(userId);
            try
            {
                using (var db = new PFEDatabaseEntities())
                {
                    if (db.Machines.Where(w => w.MachineName == machine.MachineName).Count() == 0)
                        return "machine doesn't exist";
                    Machines m = db.Machines.First(contr => contr.MachineName == machine.MachineName);
                    m.MachineName = machine.MachineName;
                    m.MacAddress = machine.MacAddress;
                    m.Comment = machine.Comment;
                    m.Statut = machine.Statut;
                    m.local = machine.local;
                    //db.Machines.Remove(db.Machines.First(contr => contr.MachineName == machine.MachineName));
                    db.SaveChanges();

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return "remove Machine succeeded";
        }

        public override object Remove(object obj)
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
            return "remove Machine succeeded";
        }

        public void Dispose()
        {

        }

    }
}
