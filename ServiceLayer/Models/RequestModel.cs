using System.Linq;
using Models;


namespace Service.Models
{
    public class RequestModel
    {
        public UserDTO UserDTO { get; set; }
        public MachinesDTO MachineDTO { get; set; }
        public ProblemsDTO ProblemDTO { get; set; }

        public object FindCorrectDTO()
        {
            return new object[] { UserDTO, MachineDTO, ProblemDTO }.FirstOrDefault(w => w != null);
        }
    }
}