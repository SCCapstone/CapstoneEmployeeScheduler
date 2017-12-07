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
    class RoleDAO
    {
        private static string con = (string)System.Windows.Application.Current.FindResource("Connection");

        public Role createRole(Role role)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            // Create and prepare an SQL statement.
            command.CommandText =
                "INSERT INTO Roles (RoleName, RoleDescription) " +
                "VALUES (@rolename, @roledescription)";

            SqlParameter roleNameParam = new SqlParameter("@rolename", SqlDbType.Text, 255);
            SqlParameter roleDescriptionParam = new SqlParameter("@roledescription", SqlDbType.Text, 255);

            roleNameParam.Value = role.RoleName;
            roleDescriptionParam.Value = role.RoleDescription;

            command.Parameters.Add(roleNameParam);
            command.Parameters.Add(roleDescriptionParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            command.ExecuteNonQuery();

            return role;
        }

        public Role editRole(Role role)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            // Create and prepare an SQL statement.
            command.CommandText =
                "UPDATE Roles SET RoleName = @rolename, RoleDescription = @roledescription WHERE ID = @id";

            SqlParameter roleNameParam = new SqlParameter("@rolename", SqlDbType.Text, 255);
            SqlParameter roleDescriptionParam = new SqlParameter("@rolename", SqlDbType.Text, 255);
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int, 10);

            roleNameParam.Value = role.RoleName;
            roleDescriptionParam.Value = role.RoleDescription;
            idParam.Value = role.Id;

            command.Parameters.Add(roleNameParam);
            command.Parameters.Add(roleDescriptionParam);
            command.Parameters.Add(idParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            command.ExecuteNonQuery();

            return role;
        }

        public Role getRoleById(int id)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand command = new SqlCommand(null, connection);

            command.CommandText =
                "SELECT * FROM Roles WHERE ID = @id";

            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int, 10);

            idParam.Value = id;

            command.Parameters.Add(idParam);

            Role role = new Model.Role();
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
                    Role role = new Model.Role();
                    role.Id = reader.GetInt32(0);
                    role.RoleName = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                    {
                        role.RoleDescription = reader.GetString(2);
                    }
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
