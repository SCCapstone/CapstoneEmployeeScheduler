using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneEmployeeScheduler.Model;

namespace CapstoneEmployeeScheduler.Algorithm
{
    class ScheduleElement
    {
        private Role r;
        private User u;

        public Role role
        {
            get
            {
                return r;
            }
            set
            {
                r = value;
            }
        }

        public User user
        {
            get
            {
                return u;
            }
            set
            {
                u = value;
            }
        }
    }
}
