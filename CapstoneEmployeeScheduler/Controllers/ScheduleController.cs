using CapstoneEmployeeScheduler.DAOs;
using CapstoneEmployeeScheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneEmployeeScheduler.Controllers
{
    class ScheduleController
    {
        public void createSchedule(Schedule schedule)
        {
            ScheduleDAO scheduleDAO = null;
            try
            {
                scheduleDAO = new ScheduleDAO();
            }
            catch (System.TypeInitializationException)
            {
            }
            scheduleDAO.createSchedule(schedule);
        }

        public Schedule getScheduleByDate(DateTime date)
        {
            ScheduleDAO scheduleDAO = null;
            try
            {
                scheduleDAO = new ScheduleDAO();
            }
            catch (System.TypeInitializationException)
            {
            }
            return scheduleDAO.getScheduleByDate(date);
        }

        public Schedule getLastSchedule(int daysPassed)
        {
            ScheduleDAO scheduleDAO = null;
            try
            {
                scheduleDAO = new ScheduleDAO();
            }
            catch (System.TypeInitializationException)
            {

            }
            return scheduleDAO.getLastSchedule(daysPassed);
        }
    }
}
