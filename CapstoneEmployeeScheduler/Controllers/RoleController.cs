using CapstoneEmployeeScheduler.DAO;
using CapstoneEmployeeScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneEmployeeScheduler.Controllers
{
    class RoleController
    {
        /// <summary>
        /// Basic method to create a role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public Role createRole(Role role)
        {
            RoleDAO roleDAO = null;
            try
            {
                roleDAO = new RoleDAO();

            }
            catch (System.TypeInitializationException)
            {

            }

            return roleDAO.createRole(role);
        }

        /// <summary>
        /// Basic method for editing a role
        /// </summary>
        /// <param name="role"></param>
        public void editRole(Role role)
        {
            RoleDAO roleDAO = null;
            try
            {
                roleDAO = new RoleDAO();

            }
            catch (System.TypeInitializationException)
            {

            }
            roleDAO.editRole(role);
        }

        /// <summary>
        /// Basic method for deleting a role
        /// </summary>
        /// <param name="id"></param>
        public void deleteRole(int id)
        {
            RoleDAO roleDAO = null;
            try
            {
                roleDAO = new RoleDAO();

            }
            catch (System.TypeInitializationException)
            {

            }
            roleDAO.deleteRole(id);
        }

        /// <summary>
        /// This method returns a single role
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Role</returns>
        public Role getRoleById(int id)
        {
            RoleDAO roleDAO = null;
            try
            {
                roleDAO = new RoleDAO();

            }
            catch (System.TypeInitializationException)
            {

            }
            return roleDAO.getRoleById(id);
        }

        /// <summary>
        /// Returns all roles
        /// </summary>
        /// <returns>List<Role></returns>
        public List<Role> getAllRoles()
        {
            RoleDAO roleDAO = null;
            try
            {
                roleDAO = new RoleDAO();

            }
            catch (System.TypeInitializationException)
            {

            }
            return roleDAO.getAllRoles();
        }
    }
}
