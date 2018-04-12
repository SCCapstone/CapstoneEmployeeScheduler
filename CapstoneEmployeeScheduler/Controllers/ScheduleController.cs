﻿using CapstoneEmployeeScheduler.DAOs;
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

        public void createSchedule(Schedule schedule)
        {
            scheduleDAO.createSchedule(schedule);
        }

        public Schedule getScheduleByDate(DateTime date)
        {
            return scheduleDAO.getScheduleByDate(date);
        }

        public Schedule getLastSchedule(int daysPassed)
        {
            return scheduleDAO.getLastSchedule(daysPassed);
        }

        public void deleteSchedule(int id)
        {
            scheduleDAO.deleteSchedule(id);
        }
    }
}
