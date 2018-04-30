using CapstoneEmployeeScheduler.Models;
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
        
        /// <summary>
        /// Creates a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User createUser(User user)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            // Create and prepare an SQL statement.
            command.CommandText =
                "INSERT INTO Users (UserName, Email, Shift, OutOfWork, Disabled, Admin, Password) " +
                "VALUES (@username, @email, @shift, @outofwork, @disabled, @admin, @password); SELECT CAST(scope_identity() AS int)";
            


            SqlParameter userNameParam = new SqlParameter("@username", SqlDbType.Text, 255);
            SqlParameter emailParam = new SqlParameter("@email", SqlDbType.Text, 255);
            SqlParameter shiftParam = new SqlParameter("@shift", SqlDbType.Text, 255);
            SqlParameter outOfWorkParam = new SqlParameter("@outofwork", SqlDbType.Bit, 10);
            SqlParameter disabledParam = new SqlParameter("@disabled", SqlDbType.Bit, 10);
            SqlParameter adminParam = new SqlParameter("@admin", SqlDbType.Bit, 10);
            SqlParameter passwordParam = new SqlParameter("@password", SqlDbType.Text, 255);

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
            //command.ExecuteNonQuery();
            int id = (Int32)command.ExecuteScalar();
            user.Id = id;
            return user;
        }

        /// <summary>
        /// Deletes role from user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        public void deleteRoleFromUser(int userId, int roleId)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            // Create and prepare an SQL statement.
            command.CommandText =
                "DELETE FROM User_Roles WHERE User_ID = @userid AND Role_ID = @roleid";

            SqlParameter userIdParam = new SqlParameter("@userid", SqlDbType.Int, 20);
            SqlParameter roleIdParam = new SqlParameter("@roleid", SqlDbType.Int, 20);

            userIdParam.Value = userId;
            roleIdParam.Value = roleId;

            command.Parameters.Add(userIdParam);
            command.Parameters.Add(roleIdParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes a user by id
        /// </summary>
        /// <param name="id"></param>
        public void deleteUserById(int id)
        {
            deleteUserRoles(id);
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            
            command.CommandText =
                "DELETE FROM Users WHERE ID = @id";

            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int, 32);
            
            idParam.Value = id;

            command.Parameters.Add(idParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Delete a user from the user roles table
        /// </summary>
        /// <param name="id"></param>
        private void deleteUserRoles(int id)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            // Create and prepare an SQL statement.
            command.CommandText =
                "DELETE FROM User_Roles WHERE User_ID = @id";

            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int, 20);

            idParam.Value = id;

            command.Parameters.Add(idParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Edits a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User editUser(User user)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            // Create and prepare an SQL statement.
            command.CommandText =
                "UPDATE Users SET UserName = @username, Email = @email, Shift = @shift, OutOfWork = @outofwork, Disabled = @disabled, Admin = @Admin, Password = @password WHERE ID = @id";

            SqlParameter userNameParam = new SqlParameter("@username", SqlDbType.Text, 100);
            SqlParameter emailParam = new SqlParameter("@email", SqlDbType.Text, 255);
            SqlParameter shiftParam = new SqlParameter("@shift", SqlDbType.Text, 255);
            SqlParameter outOfWorkParam = new SqlParameter("@outofwork", SqlDbType.Bit, 10);
            SqlParameter disabledParam = new SqlParameter("@disabled", SqlDbType.Bit, 10);
            SqlParameter adminParam = new SqlParameter("@admin", SqlDbType.Bit, 10);
            SqlParameter passwordParam = new SqlParameter("@password", SqlDbType.Text, 255);
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int, 20);

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

            return user;// = new Models.User();
        }

        /// <summary>
        /// Gets user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User getUserById(int id)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            command.CommandText =
                "SELECT * FROM Users WHERE ID = @id";
            
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int, 20);
            
            idParam.Value = id;
            
            command.Parameters.Add(idParam);

            User user = new Models.User();
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
            connection.Close();
            return user;
        }

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns></returns>
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
                    User user = new Models.User();
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
            connection.Close();
            return users;
        }

        /// <summary>
        /// Adds a role to a user
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="roleID"></param>
        public void addRoleToUser(int userID, int roleID)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            // Create and prepare an SQL statement.
            command.CommandText = "INSERT INTO user_roles(User_ID, Role_ID) VALUES(@userid, @roleid)";

            SqlParameter userIDParam = new SqlParameter("@userid", SqlDbType.Int, 32);
            SqlParameter roleIDParam = new SqlParameter("@roleid", SqlDbType.Int, 32);

            userIDParam.Value = userID;
            roleIDParam.Value = roleID;

            command.Parameters.Add(userIDParam);
            command.Parameters.Add(roleIDParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Gets all role ids for user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Role> getRoleIdForUser(User user)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            // Create and prepare an SQL statement.
            command.CommandText = "SELECT * FROM User_Roles WHERE User_ID = @userid";

            SqlParameter userIDParam = new SqlParameter("@userid", SqlDbType.Int, 32);

            userIDParam.Value = user.Id;

            command.Parameters.Add(userIDParam);

            List<Role> roles = new List<Role>();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Role role = new Role();
                    role.Id = reader.GetInt32(1);//1 b/c user is at 0
                    roles.Add(role);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
            return roles;
        }

        /// <summary>
        /// Gets all roles for user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Role> getRolesForUser(User user)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            // Create and prepare an SQL statement.
            command.CommandText = "SELECT * FROM User_Roles WHERE User_ID = @userid";

            SqlParameter userIDParam = new SqlParameter("@userid", SqlDbType.Int, 32);

            userIDParam.Value = user.Id;

            command.Parameters.Add(userIDParam);

            List<Role> roles = new List<Role>();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Role role = new Role();
                    role.Id = reader.GetInt32(1);
                    roles.Add(role);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
            return getNameForRoles(roles);
        }

        /// <summary>
        /// Gets the name for roles
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        private List<Role> getNameForRoles(List<Role> roles)
        {
            List<Role> returnRoles = new List<Role>();
            foreach (Role role in roles)
            {
                SqlConnection connection = new SqlConnection(con);
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                // Create and prepare an SQL statement.
                command.CommandText = "SELECT * FROM Roles WHERE ID = @roleid";

                SqlParameter userIDParam = new SqlParameter("@roleid", SqlDbType.Int, 32);

                userIDParam.Value = role.Id;

                command.Parameters.Add(userIDParam);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        role.Id = reader.GetInt32(0);
                        role.RoleName = reader.GetString(1);
                        if (!reader.IsDBNull(2))
                        {
                            role.RoleDescription = reader.GetString(2);
                        }
                        if (!reader.IsDBNull(3))
                            role.RoleCount = reader.GetInt32(3);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();
                returnRoles.Add(role);
            }
            return returnRoles;
        }
    }
    
}
