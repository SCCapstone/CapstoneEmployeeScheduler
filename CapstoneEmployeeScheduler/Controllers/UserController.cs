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
            user = userDAO.createUser(user);
            if (user.Roles != null)
            {
                List<Role> roles = user.Roles;
                foreach (Role role in roles)
                {
                    addRoleToUser(user.Id, role.Id);
                }
            }
        }
        
        public void editUser(User user)
        {
            userDAO.editUser(user);
            if (user.Roles != null)
            {
                List<Role> roles = user.Roles;
                foreach (Role role in roles)
                {
                    addRoleToUser(user.Id, role.Id);
                }
            }
        }

        public User getUserById(int id)
        {
            User user = userDAO.getUserById(id);
            user.Roles = getRolesForUser(user);
            return user;
        }

        public List<User> getAllUsersWithoutRoles()
        {
            List<User> users = new List<User>();
            users = userDAO.getAllUsers();
            return users;
        }

        public List<User> getAllUsersWithEntireRole()
        {
            List<User> users = new List<User>();
            users = userDAO.getAllUsers();
            foreach(User user in users)
            {
                user.Roles = getRolesForUser(user);
            }
            return users;
        }

        public List<User> getAllUsersWithRoleId()
        {
            List<User> users = new List<User>();
            users = userDAO.getAllUsers();
            foreach (User user in users)
            {
                user.Roles = getRoleIdForUser(user);
            }
            return users;
        }

        public void deleteUserById(int id)
        {
            userDAO.deleteUserById(id);
        }

        private void addRoleToUser(int userID, int roleID)
        {
            userDAO.addRoleToUser(userID, roleID);
        }

        private List<Role> getRolesForUser(User user)
        {
            return userDAO.getRolesForUser(user);
        }

        private List<Role> getRoleIdForUser(User user)
        {
            return userDAO.getRoleIdForUser(user);
        }
    }
}
