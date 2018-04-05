using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneEmployeeScheduler.Models
{
    class Schedule
    {
        private string id;
        private Dictionary<int, int> userRoles = new Dictionary<int, int>();
        DateTime scheduleDate;

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

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public DateTime ScheduleDate
        {
            get
            {
                return scheduleDate;
            }

            set
            {
                scheduleDate = value;
            }
        }
    }
}
