using CapstoneEmployeeScheduler.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneEmployeeScheduler.DAOs
{
    class ScheduleDAO
    {
        private static string con = (string)System.Windows.Application.Current.FindResource("Connection");

        /// <summary>
        /// Creates 
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        public Schedule createSchedule(Schedule schedule)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);
            SqlParameter userIDParam = null;
            SqlParameter roleIDParam = null;
            SqlParameter idParam = null;
            SqlParameter scheduleDateParam = null;
            string id = Guid.NewGuid().ToString();
            DateTime date;
            if (schedule.ScheduleDate == null)
            {
                date = DateTime.Today;
            }
            else
            {
                date = schedule.ScheduleDate;
            }
            int count = schedule.UserRoles.Count;
            for (int i=0;i<count;i++)
            {
                command.Parameters.Clear();
                command.CommandText =
                "INSERT INTO Schedule (ID, User_ID, Role_ID, ScheduleDate) " +
                "VALUES (@id, @userid, @roleid, @scheduledate);";
                idParam = new SqlParameter("@id", SqlDbType.Text, 255);
                userIDParam = new SqlParameter("@userid", SqlDbType.Int, 32);
                roleIDParam = new SqlParameter("@roleid", SqlDbType.Int, 32);
                scheduleDateParam = new SqlParameter("@scheduledate", SqlDbType.DateTime, 255);
                idParam.Value = id;
                userIDParam.Value = schedule.UserRoles.Keys.First();
                roleIDParam.Value = schedule.UserRoles[int.Parse(userIDParam.Value.ToString())];
                scheduleDateParam.Value = date;
                schedule.UserRoles.Remove((int)userIDParam.Value);
                command.Parameters.Add(idParam);
                command.Parameters.Add(userIDParam);
                command.Parameters.Add(roleIDParam);
                command.Parameters.Add(scheduleDateParam);
                command.Prepare();
                command.ExecuteNonQuery();
            }
            schedule.Id = id;
            schedule.ScheduleDate = date;
            return schedule;
        }

        public void editSchedule(Schedule schedule)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);
            deleteSchedule(schedule.Id);
            createSchedule(schedule);
        }

        public void deleteSchedule(string id)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            command.CommandText =
                "DELETE FROM Schedule WHERE ID = @id";

            SqlParameter idParam = new SqlParameter("@id", SqlDbType.VarChar, 255);

            idParam.Value = id;

            command.Parameters.Add(idParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            command.ExecuteNonQuery();
        }

        public Schedule getScheduleByDate(DateTime date)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            command.CommandText =
                "SELECT * FROM Schedule WHERE ScheduleDate = @scheduledate";

            SqlParameter scheduleDateParam = new SqlParameter("@scheduledate", SqlDbType.DateTime, 255);

            scheduleDateParam.Value = date;

            command.Parameters.Add(scheduleDateParam);

            Schedule schedule = new Models.Schedule();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    schedule.Id = reader.GetString(0);
                    schedule.ScheduleDate = reader.GetDateTime(3);
                    schedule.UserRoles.Add(reader.GetInt32(1), reader.GetInt32(2));
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
            return schedule;
        }

        public Schedule getLastSchedule(int daysPassed)
        {
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand comm = new SqlCommand(null, conn);

            comm.CommandText =
                "SELECT * FROM Schedule s WHERE " + daysPassed + "=(SELECT COUNT(DISTINCT ScheduleDate) FROM Schedule sc WHERE s.ScheduleDate<=sc.ScheduleDate)";
           
            Schedule sched = new Models.Schedule();
            SqlDataReader read = comm.ExecuteReader();

            if (read.HasRows)
            {
                while (read.Read())
                {
                    sched.Id = read.GetString(0);
                    sched.ScheduleDate = read.GetDateTime(3);
                    if (sched.UserRoles.ContainsKey(read.GetInt32(1))){

                    }
                    else
                    {
                        sched.UserRoles.Add(read.GetInt32(1), read.GetInt32(2));
                    }
                }
             }
            else
            {
                Console.WriteLine("No rows found.");
            }
            read.Close();
            return sched;
        }
    }
}
