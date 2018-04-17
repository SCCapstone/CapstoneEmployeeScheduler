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
