using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneEmployeeScheduler.DAO
{
    class UserDAO
    {
        SqlConnection con = new SqlConnection("user id=chanc; " +
                                              "password=password;server=(localdb)\\MSSQLLocalDB; " +
                                              "Trusted_Connection=yes; " +
                                              "database=Dev; " +
                                              "connection timeout=30");*/
        public User createUser(User user)
        {

        }
    }
}
