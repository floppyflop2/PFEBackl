using DataModel;
using Models;
using System.Collections.Generic;

namespace DataMapper
{
    public static class DatabaseMapper
    {
        public static UserDTO MapToUserDTO(Users user)
        {
            return new UserDTO()
            {
                UserId = user.UserId,
                UserEmail = user.UserEmail,
                AspNetUserId = user.AspNetUserId
            };
        }
        public static List<UserDTO> MapToUserDTO(List<Users> users)
        {
            List<UserDTO> listOfUsers = new List<UserDTO>();
            users.ForEach(s => listOfUsers.Add(MapToUserDTO(s)));
            return listOfUsers;
        }

        public static MachinesDTO MapToMachinesDTO(Machines machine)
        {
            return new MachinesDTO
            {
                MachineId = machine.MachineId,
                MachineName = machine.MachineName,
                MacAddress = machine.MacAddress,
                Comment = machine.Comment,
                Statut = machine.Statut,
                local = machine.local
            };
        }

        public static List<MachinesDTO> MapToMachinesDTO(List<Machines> machines)
        {
            List<MachinesDTO> listOfMachines = new List<MachinesDTO>();
            machines.ForEach(m => listOfMachines.Add(MapToMachinesDTO(m)));
            return listOfMachines;
        }

        public static ProblemsDTO MapToProblemsDTO(Problems problem)
        {
            return new ProblemsDTO
            {
                ProblemId = problem.ProblemId,
                ProbDescription = problem.ProbDescription,
                Photo = problem.Photo,
                MachineId = problem.MachineId,
                UserId = problem.UserId,
                DateProb = problem.DateProb,
                Statut = problem.Statut,
                isFixed = problem.Fixed
            };
        }

        public static List<ProblemsDTO> MapToProblemsDTO(List<Problems> problems)
        {
            List<ProblemsDTO> listOfProblems = new List<ProblemsDTO>();
            problems.ForEach(p => listOfProblems.Add(MapToProblemsDTO(p)));
            return listOfProblems;
        }
    }
}
