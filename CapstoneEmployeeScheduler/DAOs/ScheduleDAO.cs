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

            // Create and prepare an SQL statement.
            command.CommandText =
                "INSERT INTO Schedules (UserID, RoleID) " +
                "VALUES (@userid, @roleid); SELECT CAST(scope_identity() AS int)";



            SqlParameter userIDParam = new SqlParameter("@userid", SqlDbType.Int, 32);
            SqlParameter roleIDParam = new SqlParameter("@roleid", SqlDbType.Int, 32);

            userIDParam.Value = schedule.userRoles.Keys.ElementAt(0);
            roleIDParam.Value = schedule.userRoles.Values.ElementAt(0);

            command.Parameters.Add(userIDParam);
            command.Parameters.Add(roleIDParam);

            //// Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            //command.ExecuteNonQuery();
            int id = (Int32)command.ExecuteScalar();
            schedule.Id = id;
            return schedule;
        }
    }
}
