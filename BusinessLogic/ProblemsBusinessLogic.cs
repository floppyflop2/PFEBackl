﻿
using System;
using System.Linq;
using Models;
using DataModel;
using System.Collections.Generic;
using static DataMapper.DatabaseMapper;

namespace BusinessLogic
{
    public class ProblemsBusinessLogic : BaseBusinessLogic
    {
        public object GetAll()
        {
            List<Problems> result;
            try
            {
                using (var db = new PFEDatabaseEntities())
                {
                    result = db.Problems.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return MapToProblemsDTO(result);
        }

        public override object Get(string id)
        {
            int idProb;
            List<Problems> result = null;
            // GETS ALL THE MACHINES IF ID == 0
            if (id == "0")
            {
                return GetAll();
            }      
            else
            {
                try
                {

                    idProb = Int32.Parse(id);
                    using (var db = new PFEDatabaseEntities())
                    {
                        result = db.Problems.Where(c => c.ProblemId == idProb).ToList();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            return MapToProblemsDTO(result);
        }

        public override object Add(object obj, string ProbId)
        {
            ProblemsDTO prob = (ProblemsDTO)obj;
            if (prob.Statut == null) prob.Statut = "Random";
            try
            {
                using (var db = new PFEDatabaseEntities())
                {
                    //var result = db.Problems.FirstOrDefault(c => c.ProblemId == prob.ProblemId);
                    //if (!obj.Equals(result))
                    db.Problems.Add(new Problems()
                    {
                        DateProb = DateTime.Now,//TODO on mets la date nous même  ? 
                        Fixed = false,
                        MachineId = db.Machines.Where(m => m.MachineName == prob.MachineName).First().MachineId,
                        //UserId = db.Users.Where(u => u.UserId == prob.UserId).First().UserId,
                        UserId = 20,//TODO to be modified if relation with user
                        Photo = prob.Photo,
                        ProbDescription = prob.ProbDescription,
                        Statut = prob.Statut,
                        UserEmail = prob.UserEmail
                    });
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return "add succeeded";
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
                        DateProb = DateTime.Now,
                        Fixed = false,
                        MachineId = db.Machines.Where(m => m.MachineName == prob.MachineName).First().MachineId,
                        UserId = db.Users.Where(u => u.UserId == prob.UserId).First().UserId,
                        Photo = prob.Photo,
                        ProbDescription = prob.ProbDescription,
                        Statut = prob.Statut,
                        UserEmail = prob.UserEmail

                    });
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + "problem modified");
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
                throw new Exception(e.Message + "problem removing");
            }
        }


        public void Dispose()
        {

        }

    }
}
