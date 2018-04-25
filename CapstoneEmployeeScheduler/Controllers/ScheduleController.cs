using CapstoneEmployeeScheduler.DAOs;
using CapstoneEmployeeScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneEmployeeScheduler.Controllers
{
    class ScheduleController
    {
        ScheduleDAO scheduleDAO = new ScheduleDAO();

        /// <summary>
        /// Creates a schedule
        /// </summary>
        /// <param name="schedule"></param>
        public void createSchedule(Schedule schedule)
        {
            scheduleDAO.createSchedule(schedule);
        }

        /// <summary>
        /// Gets a schedule by the date of the schedule
        /// Since there is only one schedule made per day,
        /// this should get only one schedule
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Schedule</returns>
        public Schedule getScheduleByDate(DateTime date)
        {
            return scheduleDAO.getScheduleByDate(date);
        }

        /// <summary>
        /// This gets the last generated schedule
        /// </summary>
        /// <param name="daysPassed"></param>
        /// <returns>Schedule</returns>
        public Schedule getLastSchedule(int daysPassed)
        {
            return scheduleDAO.getLastSchedule(daysPassed);
        }

        /// <summary>
        /// This deletes a schedule based on id
        /// </summary>
        /// <param name="id"></param>
        public void deleteSchedule(string id)
        {
            scheduleDAO.deleteSchedule(id);
        }

        /// <summary>
        /// Edits a schedule
        /// </summary>
        /// <param name="schedule"></param>
        public void editSchedule(Schedule schedule)
        {
            scheduleDAO.editSchedule(schedule);
        }
    }
}
