using CapstoneEmployeeScheduler.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CapstoneEmployeeScheduler.DAO
{
    class UserDAO
    {
        private static string con = (string)System.Windows.Application.Current.FindResource("Connection");
        
        public User createUser(User user)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            // Create and prepare an SQL statement.
            command.CommandText =
                "INSERT INTO Users (UserName, Email, Shift, OutOfWork, Disabled, Admin, Password) " +
                "VALUES (@username, @email, @shift, @outofwork, @disabled, @admin, @password)";

            SqlParameter userNameParam = new SqlParameter("@username", SqlDbType.Text, 100);
            SqlParameter emailParam = new SqlParameter("@email", SqlDbType.Text, 10);
            SqlParameter shiftParam = new SqlParameter("@shift", SqlDbType.Text, 10);
            SqlParameter outOfWorkParam = new SqlParameter("@outofwork", SqlDbType.Bit, 10);
            SqlParameter disabledParam = new SqlParameter("@disabled", SqlDbType.Bit, 10);
            SqlParameter adminParam = new SqlParameter("@admin", SqlDbType.Bit, 10);
            SqlParameter passwordParam = new SqlParameter("@password", SqlDbType.Text, 10);

            userNameParam.Value = user.UserName;
            emailParam.Value = user.Email;
            shiftParam.Value = user.Shift;
            outOfWorkParam.Value = user.OutOfWork;
            disabledParam.Value = user.Disabled;
            adminParam.Value = user.Admin;
            passwordParam.Value = user.Password;

            command.Parameters.Add(userNameParam);
            command.Parameters.Add(emailParam);
            command.Parameters.Add(shiftParam);
            command.Parameters.Add(outOfWorkParam);
            command.Parameters.Add(disabledParam);
            command.Parameters.Add(adminParam);
            command.Parameters.Add(passwordParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            command.ExecuteNonQuery();

            return user;// = new User();
        }

        public User editUser(User user)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            // Create and prepare an SQL statement.
            command.CommandText =
                "UPDATE Users SET UserName = @username, Email = @email, Shift = @shift, OutOfWork = @outofwork, Disabled = @disabled, Admin = @Admin, Password = @password WHERE ID = @id";

            SqlParameter userNameParam = new SqlParameter("@username", SqlDbType.Text, 100);
            SqlParameter emailParam = new SqlParameter("@email", SqlDbType.Text, 10);
            SqlParameter shiftParam = new SqlParameter("@shift", SqlDbType.Text, 10);
            SqlParameter outOfWorkParam = new SqlParameter("@outofwork", SqlDbType.Bit, 10);
            SqlParameter disabledParam = new SqlParameter("@disabled", SqlDbType.Bit, 10);
            SqlParameter adminParam = new SqlParameter("@admin", SqlDbType.Bit, 10);
            SqlParameter passwordParam = new SqlParameter("@password", SqlDbType.Text, 10);
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int, 10);

            userNameParam.Value = user.UserName;
            emailParam.Value = user.Email;
            shiftParam.Value = user.Shift;
            outOfWorkParam.Value = user.OutOfWork;
            disabledParam.Value = user.Disabled;
            adminParam.Value = user.Admin;
            passwordParam.Value = user.Password;
            idParam.Value = user.Id;

            command.Parameters.Add(userNameParam);
            command.Parameters.Add(emailParam);
            command.Parameters.Add(shiftParam);
            command.Parameters.Add(outOfWorkParam);
            command.Parameters.Add(disabledParam);
            command.Parameters.Add(adminParam);
            command.Parameters.Add(passwordParam);
            command.Parameters.Add(idParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            command.ExecuteNonQuery();

            return user;// = new Model.User();
        }

        public User getUserById(int id)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            command.CommandText =
                "SELECT * FROM Users WHERE ID = @id";
            
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int, 10);
            
            idParam.Value = id;
            
            command.Parameters.Add(idParam);

            User user = new Model.User();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user.Id = reader.GetInt32(0);
                    user.UserName = reader.GetString(1);
                    user.Email = reader.GetString(2);
                    user.Shift = reader.GetString(3);
                    if(!reader.IsDBNull(4))
                    {
                        user.RoleOneDayAgo = reader.GetInt32(4);
                    }
                    else
                    {
                        user.RoleOneDayAgo = null;
                    }
                    if (!reader.IsDBNull(5))
                    {
                        user.RoleOneDayAgo = reader.GetInt32(5);
                    }
                    else
                    {
                        user.RoleOneDayAgo = null;
                    }
                    if (!reader.IsDBNull(6))
                    {
                        user.RoleOneDayAgo = reader.GetInt32(6);
                    }
                    else
                    {
                        user.RoleOneDayAgo = null;
                    }
                    user.OutOfWork = reader.GetBoolean(7);
                    user.Disabled = reader.GetBoolean(8);
                    user.Admin = reader.GetBoolean(9);
                    user.Password = reader.GetString(10);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
            return user;
        }

        public List<User> getAllUsers()
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            command.CommandText =
                "SELECT * FROM Users";
            
            List<User> users = new List<User>();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                //int counter = 0;
                while (reader.Read())
                {
                    User user = new Model.User();
                    user.Id = reader.GetInt32(0);
                    user.UserName = reader.GetString(1);
                    user.Email = reader.GetString(2);
                    user.Shift = reader.GetString(3);
                    if (!reader.IsDBNull(4))
                    {
                        user.RoleOneDayAgo = reader.GetInt32(4);
                    }
                    else
                    {
                        user.RoleOneDayAgo = null;
                    }
                    if (!reader.IsDBNull(5))
                    {
                        user.RoleOneDayAgo = reader.GetInt32(5);
                    }
                    else
                    {
                        user.RoleOneDayAgo = null;
                    }
                    if (!reader.IsDBNull(6))
                    {
                        user.RoleOneDayAgo = reader.GetInt32(6);
                    }
                    else
                    {
                        user.RoleOneDayAgo = null;
                    }
                    user.OutOfWork = reader.GetBoolean(7);
                    user.Disabled = reader.GetBoolean(8);
                    user.Admin = reader.GetBoolean(9);
                    user.Password = reader.GetString(10);
                    users.Add(user);
                    //counter++;
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
            return users;
        }
    }
}
