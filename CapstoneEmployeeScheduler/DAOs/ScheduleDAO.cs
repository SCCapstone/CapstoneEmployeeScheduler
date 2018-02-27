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
            int id = 0;


            command.CommandText =
                "INSERT INTO Schedules (UserID, RoleID) " +
                "VALUES (@userid, @roleid); SELECT CAST(scope_identity() AS int)";

            userIDParam = new SqlParameter("@userid", SqlDbType.Int, 32);
            roleIDParam = new SqlParameter("@roleid", SqlDbType.Int, 32);

            userIDParam.Value = schedule.userRoles.Keys.First();
            roleIDParam.Value = schedule.userRoles[int.Parse(userIDParam.ToString())];

            schedule.userRoles.Remove((int)userIDParam.Value);

            command.Parameters.Add(userIDParam);
            command.Parameters.Add(roleIDParam);

            command.Prepare();
            id = (Int32)command.ExecuteScalar();

            for (int i=0;i<schedule.userRoles.Count;i++)
            {
                command.CommandText =
                "INSERT INTO Schedules (ID, UserID, RoleID) " +
                "VALUES (@id, @userid, @roleid);";

                idParam = new SqlParameter("@id", SqlDbType.Int, 32);
                userIDParam = new SqlParameter("@userid", SqlDbType.Int, 32);
                roleIDParam = new SqlParameter("@roleid", SqlDbType.Int, 32);

                idParam.Value = id;
                userIDParam.Value = schedule.userRoles.Keys.First();
                roleIDParam.Value = schedule.userRoles[int.Parse(userIDParam.ToString())];

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
