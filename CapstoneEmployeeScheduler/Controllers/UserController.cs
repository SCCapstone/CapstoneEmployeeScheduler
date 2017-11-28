using CapstoneEmployeeScheduler.DAO;
using CapstoneEmployeeScheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneEmployeeScheduler.Controllers
{
    class UserController
    {
        UserDAO userDAO = new UserDAO();

        public void createUser(User user)
        {
            userDAO.createUser(user);
            User user2 = userDAO.getUserById(user.Id);
            Console.WriteLine(user2.Id);
            Console.WriteLine(user2.UserName);
            Console.WriteLine(user2.RoleOneDayAgo);
            Console.WriteLine(user2.Email);

            //if we need to return the user instead of void: return user;
        }

        //Haven't tested
        public void editUser(User user)
        {
            userDAO.editUser(user);
        }
    }
}
