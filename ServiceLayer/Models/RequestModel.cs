using System.Linq;
using Models;
using System.Collections.Generic;

namespace Service.Models
{
    public class RequestModel
    {
        public UserDTO UserDTO { get; set; }
        public MachinesDTO MachineDTO { get; set; }
        public ProblemsDTO ProblemDTO { get; set; }
        public List<MachinesDTO> MachineList { get; set; }

        public object FindCorrectDTO()
        {
            return new object[] { UserDTO, MachineDTO, ProblemDTO , MachineList}.FirstOrDefault(w => w != null);
        }
    }
}