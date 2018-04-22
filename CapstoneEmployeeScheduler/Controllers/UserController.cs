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
        UserDAO userDAO = null;
        
        /// <summary>
        /// This method takes in a User and creates a user in our database, any roles attached to this user are also
        /// linked to the user in the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>User</returns>
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
        
        /// <summary>
        /// This method takes in a User and finds that user in the database,
        /// then adds any new roles that were assigned to this user, 
        /// then deletes any roles that were unassigned from the user
        /// </summary>
        /// <param name="user"></param>
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
        /// <summary>
        /// This removes a role from a User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
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

        /// <summary>
        /// This is our default method for getting a User
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>
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

        /// <summary>
        /// This method was created to speed up pages because
        /// it returns a list of users without any roles 
        /// attached to them so that not near as many database
        /// </summary>
        /// <returns>List<User></returns>
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

        /// <summary>
        /// This method is the best way to get all the users,
        /// however if the database has a lot of users in it,
        /// this method takes a long to because it has to make
        /// a lot of database calls
        /// </summary>
        /// <returns>List<User></returns>
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

        /// <summary>
        /// This method doesn't take as long as getting the entire role,
        /// but it still gets the role id so it's the ideal method to use
        /// for making the schedule
        /// </summary>
        /// <returns>List<User></returns>
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

        /// <summary>
        /// This is our default way to delete a User from the database
        /// </summary>
        /// <param name="id"></param>
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

        /// <summary>
        /// This method adds a role to a User
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="roleID"></param>
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

        /// <summary>
        /// This method is used to retrieve all the current roles for a User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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

        /// <summary>
        /// This method is a faster way to get a role for a user
        /// because it just gets the role id
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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
