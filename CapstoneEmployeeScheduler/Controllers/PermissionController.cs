using CapstoneEmployeeScheduler.DAOs;
using CapstoneEmployeeScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneEmployeeScheduler.Controllers
{
    class PermissionController
    {
        PermissionDAO permDAO = new PermissionDAO();

        public void editPermissions(Permission perm)
        {
            permDAO.editPermission(perm);
        }

        public Permission getPermissions()
        {
            return permDAO.getPermission();
        }
    }
}
