using CapstoneEmployeeScheduler.Model;
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
            DateTime date = DateTime.Today;
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

            Schedule schedule = new Model.Schedule();
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

    }
}
