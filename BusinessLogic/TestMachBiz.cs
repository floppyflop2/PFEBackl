using DataModel;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataMapper.DatabaseMapper;

namespace BusinessLogic
{
    public class TestMachBiz : BaseBusinessLogic
    {

        public override object Get(string id)
        {
            MachinesDTO m;
            try
            {
                using (var db = new PFEDatabaseEntities())
                {
                    m = MapToMachinesDTO(db.Machines.Where(w => w.MachineName == id).First());
                }
            }catch(Exception e)
            {
                return e.Message;
            }
            
            return m;
        }

        public override object Add(object obj, string id)
        {
            MachinesDTO mach = (MachinesDTO)obj; 
            try
            {
                using (var db = new PFEDatabaseEntities())
                {
                    db.Machines.Add(MapToMachines(mach));
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "add succeed";
        }

        public override void Modify(object obj, string id)
        {
            MachinesDTO mach = (MachinesDTO)obj;
            try
            {
                using (var db = new PFEDatabaseEntities())
                {
                  Machines machine =  db.Machines.Where(m => m.MachineName == mach.MachineName).First();
                    machine.MacAddress = mach.MacAddress;
                    machine.Statut = mach.Statut;
                    machine.local = mach.local;
                    machine.IpAddress = mach.IpAddress;
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception( e.Message);
            }
            //return "add succeed";
        }

        public override void Remove(object obj)
        {
            MachinesDTO mach = (MachinesDTO)obj;
            try
            {
                using (var db = new PFEDatabaseEntities())
                {
                    Machines machine = db.Machines.Where(m => m.MachineName == mach.MachineName).First();
                    db.Machines.Remove(machine);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            //return "add succeed";
        }

    }
}
