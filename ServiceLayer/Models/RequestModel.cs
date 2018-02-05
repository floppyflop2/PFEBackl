using System.Linq;
using Models;


namespace Service.Models
{
    public class RequestModel
    {
        public UserDTO UserDTO { get; set; }
     
        public object FindCorrectDTO()
        {
            return new object[] { UserDTO}.FirstOrDefault(w => w != null);
        }
    }
}