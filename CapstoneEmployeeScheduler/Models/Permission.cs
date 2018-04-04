using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneEmployeeScheduler.Models
{
    class Permission
    {
        private bool employeePage;
        private bool rolePage;
        private bool historyPage;
        private bool todaysSchedule;
        private bool generateSchedule;

        public bool EmployeePage
        {
            get
            {
                return employeePage;
            }

            set
            {
                employeePage = value;
            }
        }

        public bool RolePage
        {
            get
            {
                return rolePage;
            }

            set
            {
                rolePage = value;
            }
        }

        public bool HistoryPage
        {
            get
            {
                return historyPage;
            }

            set
            {
                historyPage = value;
            }
        }

        public bool TodaysSchedule
        {
            get
            {
                return todaysSchedule;
            }

            set
            {
                todaysSchedule = value;
            }
        }

        public bool GenerateSchedule
        {
            get
            {
                return generateSchedule;
            }

            set
            {
                generateSchedule = value;
            }
        }
    }
}
