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
                "INSERT INTO Schedules (ID, UserID, RoleID) " +
                "VALUES (@id, @userid, @roleid); SELECT CAST(scope_identity() AS int)";



            SqlParameter userNameParam = new SqlParameter("@username", SqlDbType.Text, 255);
            SqlParameter emailParam = new SqlParameter("@email", SqlDbType.Text, 255);
            SqlParameter shiftParam = new SqlParameter("@shift", SqlDbType.Text, 255);
            SqlParameter outOfWorkParam = new SqlParameter("@outofwork", SqlDbType.Bit, 10);
            SqlParameter disabledParam = new SqlParameter("@disabled", SqlDbType.Bit, 10);
            SqlParameter adminParam = new SqlParameter("@admin", SqlDbType.Bit, 10);
            SqlParameter passwordParam = new SqlParameter("@password", SqlDbType.Text, 255);

            //userNameParam.Value = user.UserName;
            //emailParam.Value = user.Email;
            //shiftParam.Value = user.Shift;
            //outOfWorkParam.Value = user.OutOfWork;
            //disabledParam.Value = user.Disabled;
            //adminParam.Value = user.Admin;
            //passwordParam.Value = user.Password;

            //command.Parameters.Add(userNameParam);
            //command.Parameters.Add(emailParam);
            //command.Parameters.Add(shiftParam);
            //command.Parameters.Add(outOfWorkParam);
            //command.Parameters.Add(disabledParam);
            //command.Parameters.Add(adminParam);
            //command.Parameters.Add(passwordParam);

            //// Call Prepare after setting the Commandtext and Parameters.
            //command.Prepare();
            ////command.ExecuteNonQuery();
            //int id = (Int32)command.ExecuteScalar();
            //user.Id = id;
            return schedule;
        }
    }
}
