
using System;
using System.Linq;
using Models;
using DataModel;

namespace BusinessLogic
{
    public class MachinesBusinessLogic : BaseBusinessLogic
    { 
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

        public override object Get(string userId)
        {

            int machineId = 0;
            List<Machines> result = null;

            // GETS ALL THE MACHINES IF ID == 0
            if (userId == "0")
            {
                return GetAll();
            }

            if (!Int32.TryParse(userId, out machineId))
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

        public override object Add(object obj, string userId)
        {
            MachinesDTO machine = (MachinesDTO)obj;
            int integerId = Int32.Parse(userId);
            try
            {
                using (var db = new PFEDatabaseEntities())
                {
                    if (db.Machines.Where(cont => cont.MachineId == integerId).Count() > 0)
                        return "Already exists.";

                    db.Machines.Add(
                        new Machines()
                        {
                            MachineId = machine.MachineId,
                            MachineName = machine.MachineName,
                            MacAddress = machine.MacAddress,
                            Comment = machine.Comment,
                            Statut = machine.Statut,
                            local = machine.local
                        }
                    );
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "";
        }

        public override void Modify(object obj, string userId)
        {
            MachinesDTO machine = (MachinesDTO)obj;
            int integerId = Int32.Parse(userId);
            try
            {
                using (var db = new PFEDatabaseEntities())
                {
                    if (db.Machines.Where(w => w.MachineId == integerId).Count() == 0)
                        return;

                    db.Machines.Remove(db.Machines.First(contr => contr.MachineId == integerId));

                    db.SaveChanges();

                    db.Machines.Add(new Machines()
                    {
                        MachineId = machine.MachineId,
                        MachineName = machine.MachineName,
                        MacAddress = machine.MacAddress,
                        Comment = machine.Comment,
                        Statut = machine.Statut,
                        local = machine.local
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
            MachinesDTO machine = (MachinesDTO)obj;
            try
            {
                using (var db = new PFEDatabaseEntities())
                {
                    db.Machines.Remove(db.Machines.First(m => m.MachineId == machine.MachineId));
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
