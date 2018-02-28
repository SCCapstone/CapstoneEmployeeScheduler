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

        public Schedule createSchedule(Schedule schedule)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);
            SqlParameter userIDParam = null;
            SqlParameter roleIDParam = null;
            SqlParameter idParam = null;
            string id = Guid.NewGuid().ToString();
            int count = schedule.userRoles.Count;
            for (int i=0;i<count;i++)
            {
                command.Parameters.Clear();
                command.CommandText =
                "INSERT INTO Schedule (ID, User_ID, Role_ID) " +
                "VALUES (@id, @userid, @roleid);";
                idParam = new SqlParameter("@id", SqlDbType.Text, 255);
                userIDParam = new SqlParameter("@userid", SqlDbType.Int, 32);
                roleIDParam = new SqlParameter("@roleid", SqlDbType.Int, 32);
                idParam.Value = id;
                userIDParam.Value = schedule.userRoles.Keys.First();
                roleIDParam.Value = schedule.userRoles[int.Parse(userIDParam.Value.ToString())];
                schedule.userRoles.Remove((int)userIDParam.Value);
                command.Parameters.Add(idParam);
                command.Parameters.Add(userIDParam);
                command.Parameters.Add(roleIDParam);
                command.Prepare();
                command.ExecuteNonQuery();
            }
            schedule.Id = id;
            return schedule;
        }
    }
}
