using CapstoneEmployeeScheduler.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneEmployeeScheduler.DAO
{
    class UserDAO
    {
        SqlConnection connection = new SqlConnection("user id=chanc; " +
                                              "password=password;server=(localdb)\\MSSQLLocalDB; " +
                                              "Trusted_Connection=yes; " +
                                              "database=Dev; " +
                                              "connection timeout=30");
        public User createUser(User user)
        {
            //int ID;
            //string userName;
            //string email;
            //string shift;
            //int roleOneDayAgo;
            //int roleTwoDaysAgo;
            //int roleThreeDaysAgo;
            //bool outOfWork;
            //bool disabled;
            //bool admin;
            //string password;
            
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            // Create and prepare an SQL statement.
            command.CommandText =
                "INSERT INTO Users (UserName, Email, Shift, OutOfWork, Disabled, Admin, Password) " +
                "VALUES (@username, @email, @shift, @outofwork, @disabled, @admin, @password)";

            //SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int, 10);
            SqlParameter userNameParam = new SqlParameter("@username", SqlDbType.Text, 100);
            SqlParameter emailParam = new SqlParameter("@email", SqlDbType.Text, 10);
            SqlParameter shiftParam = new SqlParameter("@shift", SqlDbType.Text, 10);
            //SqlParameter roleOneDayAgoParam = new SqlParameter("@roleonedayago", SqlDbType.Int, 10);
            //SqlParameter roleTwoDaysAgoParam = new SqlParameter("@roletwodaysago", SqlDbType.Int, 10);
            //SqlParameter roleThreeDaysAgoParam = new SqlParameter("@rolethreedaysago", SqlDbType.Int, 10);
            SqlParameter outOfWorkParam = new SqlParameter("@outofwork", SqlDbType.Bit, 10);
            SqlParameter disabledParam = new SqlParameter("@disabled", SqlDbType.Bit, 10);
            SqlParameter adminParam = new SqlParameter("@admin", SqlDbType.Bit, 10);
            SqlParameter passwordParam = new SqlParameter("@password", SqlDbType.Text, 10);

            //idParam.Value = user.Id;
            userNameParam.Value = user.UserName;
            emailParam.Value = user.Email;
            shiftParam.Value = user.Shift;
            //roleOneDayAgoParam.Value = user.RoleOneDayAgo;
            //roleTwoDaysAgoParam.Value = user.RoleTwoDaysAgo;
            //roleThreeDaysAgoParam.Value = user.RoleThreeDaysAgo;
            outOfWorkParam.Value = user.OutOfWork;
            disabledParam.Value = user.Disabled;
            adminParam.Value = user.Admin;
            passwordParam.Value = user.Password;

            //command.Parameters.Add(idParam);
            command.Parameters.Add(userNameParam);
            command.Parameters.Add(emailParam);
            command.Parameters.Add(shiftParam);
            //command.Parameters.Add(roleOneDayAgoParam);
            //command.Parameters.Add(roleTwoDaysAgoParam);
            //command.Parameters.Add(roleThreeDaysAgoParam);
            command.Parameters.Add(outOfWorkParam);
            command.Parameters.Add(disabledParam);
            command.Parameters.Add(adminParam);
            command.Parameters.Add(passwordParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            command.ExecuteNonQuery();

                // Change parameter values and call ExecuteNonQuery.
                //command.Parameters[0].Value = 21;
                //command.Parameters[1].Value = "Second Region";
                //command.ExecuteNonQuery();
            //}
            return user = new Model.User();
        }
    }
}
