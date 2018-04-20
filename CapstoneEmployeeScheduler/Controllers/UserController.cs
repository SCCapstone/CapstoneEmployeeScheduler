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
        UserDAO userDAO = null;//new UserDAO();

        public User createUser(User user)
        {
            try
            {
                userDAO = new UserDAO();
            }
            catch (System.TypeInitializationException)
            {

            }
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
            try
            {
                userDAO = new UserDAO();
            }
            catch (System.TypeInitializationException)
            {

            }
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
            try
            {
                userDAO = new UserDAO();
            }
            catch (System.TypeInitializationException)
            {

            }
            userDAO.deleteRoleFromUser(userId, roleId);
        }

        public User getUserById(int id)
        {
            try
            {
                userDAO = new UserDAO();
            }
            catch (System.TypeInitializationException)
            {

            }
            User user = userDAO.getUserById(id);
            user.Roles = getRolesForUser(user);
            return user;
        }

        public List<User> getAllUsersWithoutRoles()
        {
            try
            {
                userDAO = new UserDAO();
            }
            catch (System.TypeInitializationException)
            {

            }
            List<User> users = new List<User>();
            users = userDAO.getAllUsers();
            return users;
        }

        public List<User> getAllUsersWithEntireRole()
        {
            try
            {
                userDAO = new UserDAO();
            }
            catch (System.TypeInitializationException)
            {

            }
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
            try
            {
                userDAO = new UserDAO();
            }
            catch (System.TypeInitializationException)
            {

            }
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
            try
            {
                userDAO = new UserDAO();
            }
            catch (System.TypeInitializationException)
            {

            }
            userDAO.deleteUserById(id);
        }

        private void addRoleToUser(int userID, int roleID)
        {
            try
            {
                userDAO = new UserDAO();
            }
            catch (System.TypeInitializationException)
            {

            }
            userDAO.addRoleToUser(userID, roleID);
        }

        private List<Role> getRolesForUser(User user)
        {
            try
            {
                userDAO = new UserDAO();
            }
            catch (System.TypeInitializationException)
            {

            }
            return userDAO.getRolesForUser(user);
        }

        private List<Role> getRoleIdForUser(User user)
        {
            try
            {
                userDAO = new UserDAO();
            }
            catch (System.TypeInitializationException)
            {

            }
            return userDAO.getRoleIdForUser(user);
        }
    }
}
