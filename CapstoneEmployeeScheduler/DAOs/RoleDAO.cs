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
                "INSERT INTO Roles (RoleName) " +
                "VALUES (@rolename)";

            SqlParameter roleNameParam = new SqlParameter("@rolename", SqlDbType.Text, 100);

            roleNameParam.Value = role.RoleName;

            command.Parameters.Add(roleNameParam);

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
                "UPDATE Roles SET roleName = @rolename WHERE ID = @id";

            SqlParameter roleNameParam = new SqlParameter("@rolename", SqlDbType.Text, 100);
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int, 10);

            roleNameParam.Value = role.RoleName;
            idParam.Value = role.Id;

            command.Parameters.Add(roleNameParam);
            command.Parameters.Add(idParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            command.ExecuteNonQuery();

            return role;
        }
    }
}
