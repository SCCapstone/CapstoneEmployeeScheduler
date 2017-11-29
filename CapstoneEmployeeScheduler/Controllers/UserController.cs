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
        }
        
        public void editUser(User user)
        {
            userDAO.editUser(user);
        }

        public User getUserById(int id)
        {
            return userDAO.getUserById(id);
        }

        public List<User> getAllUsers()
        {
            return userDAO.getAllUsers();
        }
    }
}
