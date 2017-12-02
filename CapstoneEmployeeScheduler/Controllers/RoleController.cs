using CapstoneEmployeeScheduler.DAO;
using CapstoneEmployeeScheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneEmployeeScheduler.Controllers
{
    class RoleController
    {
        RoleDAO roleDAO = new RoleDAO();

        public void createRole(Role role)
        {
            roleDAO.createRole(role);
        }

        public void editRole(Role role)
        {
            roleDAO.editRole(role);
        }

        public Role getRoleById(int id)
        {
            return roleDAO.getRoleById(id);
        }

        public List<Role> getAllRoles()
        {
            return roleDAO.getAllRoles();
        }
    }
}
