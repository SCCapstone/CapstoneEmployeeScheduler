﻿using CapstoneEmployeeScheduler.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneEmployeeScheduler.DAO
{
    class RoleDAO
    {

        //public string con = (string)System.Windows.Application.Current.FindResource("Connection");

        public Role createRole(Role role)
        {
            string con = null;
            if (null == System.Windows.Application.Current)
            {
                con = "user id = chance; password = password; server = (localdb)\\MSSQLLocalDB; Trusted_Connection = yes; database = Dev; connection timeout = 5";
            }
            else
            {
                con = (string)System.Windows.Application.Current.FindResource("Connection");
            }
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            // Create and prepare an SQL statement.
            command.CommandText =
                        "INSERT INTO Roles (RoleName, RoleDescription, Count) " +
                "VALUES (@rolename, @roledescription, @count)";

            SqlParameter roleNameParam = new SqlParameter("@rolename", SqlDbType.Text, 255);
            SqlParameter roleDescriptionParam = new SqlParameter("@roledescription", SqlDbType.Text, 255);
            SqlParameter countParam = new SqlParameter("@count", SqlDbType.Int, 10);

            roleNameParam.Value = role.RoleName;
            roleDescriptionParam.Value = role.RoleDescription;
            countParam.Value = role.RoleCount;

            command.Parameters.Add(roleNameParam);
            command.Parameters.Add(roleDescriptionParam);
            command.Parameters.Add(countParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            command.ExecuteNonQuery();

            return role;
        }

        public void deleteRole(int id)
        {
            string con = (string)System.Windows.Application.Current.FindResource("Connection");
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            // Create and prepare an SQL statement.
            command.CommandText =
                "DELETE FROM User_Roles WHERE Role_ID = @id";
            
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int, 20);

            idParam.Value = id;
            command.Parameters.Add(idParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            command.ExecuteNonQuery();

            command.CommandText =
                "DELETE FROM Roles WHERE ID = @id";

            idParam = new SqlParameter("@id", SqlDbType.Int, 20);

            idParam.Value = id;
            command.Parameters.Add(idParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            command.ExecuteNonQuery();
        }

        public Role editRole(Role role)
        {
            string con = null;
            if (null == System.Windows.Application.Current)
            {
                con = "user id = chance; password = password; server = (localdb)\\MSSQLLocalDB; Trusted_Connection = yes; database = Dev; connection timeout = 5";
            }
            else
            {
                con = (string)System.Windows.Application.Current.FindResource("Connection");
            }
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            // Create and prepare an SQL statement.
            command.CommandText =
                "UPDATE Roles SET RoleName = @rolename, RoleDescription = @roledescription, Count = @count WHERE ID = @id";

            SqlParameter roleNameParam = new SqlParameter("@rolename", SqlDbType.Text, 255);
            SqlParameter roleDescriptionParam = new SqlParameter("@rolename", SqlDbType.Text, 255);
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int, 10);
            SqlParameter countParam = new SqlParameter("@count", SqlDbType.Int, 10);

            roleNameParam.Value = role.RoleName;
            roleDescriptionParam.Value = role.RoleDescription;
            idParam.Value = role.Id;
            countParam.Value = role.RoleCount;

            command.Parameters.Add(roleNameParam);
            command.Parameters.Add(roleDescriptionParam);
            command.Parameters.Add(idParam);
            command.Parameters.Add(countParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            command.ExecuteNonQuery();

            return role;
        }

        public Role getRoleById(int id)
        {
            string con = null;
            if (null == System.Windows.Application.Current)
            {
                con = "user id = chance; password = password; server = (localdb)\\MSSQLLocalDB; Trusted_Connection = yes; database = Dev; connection timeout = 5";
            }
            else
            {
                con = (string)System.Windows.Application.Current.FindResource("Connection");
            }
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            command.CommandText =
                "SELECT * FROM Roles WHERE ID = @id";

            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int, 10);

            idParam.Value = id;

            command.Parameters.Add(idParam);

            Role role = new Models.Role();
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
                    {
                        role.RoleCount = reader.GetInt32(3);
                    }
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
            return role;
        }

        public List<Role> getAllRoles()
        {
            string con = null;
            if (null == System.Windows.Application.Current)
            {
                con = "user id = chance; password = password; server = (localdb)\\MSSQLLocalDB; Trusted_Connection = yes; database = Dev; connection timeout = 5";
            }
            else
            {
                con = (string)System.Windows.Application.Current.FindResource("Connection");
            }
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            command.CommandText =
                "SELECT * FROM Roles";

            List<Role> roles = new List<Role>();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Role role = new Models.Role();
                    role.Id = reader.GetInt32(0);
                    role.RoleName = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                    {
                        role.RoleDescription = reader.GetString(2);
                    }
                    if (!reader.IsDBNull(3))
                        role.RoleCount = reader.GetInt32(3);
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
    }
}
