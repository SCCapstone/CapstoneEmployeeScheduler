using CapstoneEmployeeScheduler.DAO;
using CapstoneEmployeeScheduler.Models;
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

        public User createUser(User user)
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
            return user;
        }
        
        public void editUser(User user)
        {
            User oldUser = getUserById(user.Id);
            userDAO.editUser(user);
            if (user.Roles != null)
            {
                List<Role> roles = user.Roles;
                foreach (Role role in roles)
                {
                    if (oldUser.Roles == null || !oldUser.Roles.Any(r => r.Id == role.Id))
                        addRoleToUser(user.Id, role.Id);
                }
            }
            if (oldUser.Roles != null)
            {
                foreach (Role role in oldUser.Roles)
                {
                    if (user.Roles == null || !user.Roles.Any(r => r.Id == role.Id))
                        deleteRoleFromUser(user.Id, role.Id);
                }
            }
        }

        private void deleteRoleFromUser(int userId, int roleId)
        {
            userDAO.deleteRoleFromUser(userId, roleId);
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
