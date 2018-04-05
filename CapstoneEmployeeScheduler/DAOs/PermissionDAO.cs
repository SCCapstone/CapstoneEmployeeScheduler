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
        private static string con = (string)System.Windows.Application.Current.FindResource("Connection");

        public void editPermission(Permission perm)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            command.CommandText =
                "UPDATE Permissions SET EmployeePage = @employeepage, RolePage = @rolepage, HistoryPage = @historypage, TodaysSchedule = @todaysschedule, GenerateSchedule = @generateSchedule";

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
    }
}
