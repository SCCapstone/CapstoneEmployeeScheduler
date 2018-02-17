using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneEmployeeScheduler.Models
{
    class Schedule
    {
        public Dictionary<int, int> userRoles;

        public Dictionary<int, int> UserRoles
        {
            get
            {
                return userRoles;
            }

            set
            {
                userRoles = value;
            }
        }
    }
}
