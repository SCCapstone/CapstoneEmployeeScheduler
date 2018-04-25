using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneEmployeeScheduler.Models;
using System.Data.SqlClient;
using System.Data;

namespace CapstoneEmployeeScheduler.DAOs
{
    class PermissionDAO
    {
        //This variable gets the connection to the current database which should be the one in Azure
        private static string con = (string)System.Windows.Application.Current.FindResource("Connection");

        /// <summary>
        /// Uses an update sql statement to edit the Permissions table in the database
        /// </summary>
        /// <param name="perm"></param>
        public void editPermission(Permission perm)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            command.CommandText =
                "UPDATE Permission SET Employee_Page = @employeepage, Role_Page = @rolepage, History_Page = @historypage, Todays_Schedule = @todaysschedule, Generate_Schedule = @generateSchedule";

            SqlParameter employeePageParam = new SqlParameter("@employeepage", SqlDbType.Bit, 5);
            SqlParameter rolePageParam = new SqlParameter("@rolepage", SqlDbType.Bit, 5);
            SqlParameter historyPageParam = new SqlParameter("@historypage", SqlDbType.Bit, 5);
            SqlParameter todaysScheduleParam = new SqlParameter("@todaysschedule", SqlDbType.Bit, 5);
            SqlParameter generateScheduleParam = new SqlParameter("@generateSchedule", SqlDbType.Bit, 5);

            employeePageParam.Value = perm.EmployeePage;
            rolePageParam.Value = perm.RolePage;
            historyPageParam.Value = perm.HistoryPage;
            todaysScheduleParam.Value = perm.TodaysSchedule;
            generateScheduleParam.Value = perm.GenerateSchedule;

            command.Parameters.Add(employeePageParam);
            command.Parameters.Add(rolePageParam);
            command.Parameters.Add(historyPageParam);
            command.Parameters.Add(todaysScheduleParam);
            command.Parameters.Add(generateScheduleParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Uses a select sql statement to get the permissions from the database
        /// </summary>
        /// <returns></returns>
        public Permission getPermission()
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            command.CommandText =
                "SELECT * FROM Permission";

            Permission perm = new Permission();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    perm.EmployeePage = reader.GetBoolean(0);
                    perm.RolePage = reader.GetBoolean(1);
                    perm.HistoryPage = reader.GetBoolean(2);
                    perm.TodaysSchedule = reader.GetBoolean(3);
                    perm.GenerateSchedule = reader.GetBoolean(4);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
            connection.Close();
            return perm;
        }
    }
}
