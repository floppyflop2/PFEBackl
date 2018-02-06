using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    public static class Operation
    {

        public static object Get(string caller, string id)
        {
            return GetBusinessLogic(caller).Get(id);
        }

        public static object Add(string caller, object obj, string id)
        {
            return GetBusinessLogic(caller).Add(obj, id);
        }

        public static void Modify(string caller, object obj, string id)
        {
            GetBusinessLogic(caller).Modify(obj, id);
        }

        public static void Remove(string caller, object obj)
        {
            GetBusinessLogic(caller).Remove(obj);
        }


        public static BaseBusinessLogic GetBusinessLogic(string caller)
        {
            switch (caller)
            {

                case "User":
                    return new UserBusinessLogic();
                case "Machine":
                    return new MachinesBusinessLogic();
                case "Problem":
                    return new ProblemsBusinessLogic();

                default:
                    return null;
            }
        }
    }
}
