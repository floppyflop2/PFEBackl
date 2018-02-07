using System;

namespace Models
{
    public class ProblemsDTO
    {
        public int ProblemId { get; set; }
        public string ProbDescription { get; set; }
        public string Photo { get; set; }
        public int MachineId { get; set; }
        public int UserId { get; set; }
        public DateTime DateProb { get; set; }
        public string Statut { get; set; }
        public bool isFixed { get; set; }
        public string UserEmail { get; set; }
    }
}