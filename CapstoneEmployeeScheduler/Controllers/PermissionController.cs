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

        /// <summary>
        /// Edits the permissions, make sure to set all the properties of a permission before
        /// calling editPermissions
        /// </summary>
        /// <param name="perm"></param>
        public void editPermissions(Permission perm)
        {
            permDAO.editPermission(perm);
        }

        /// <summary>
        /// Gets the currently set permissions
        /// This has no arguments because there is only
        /// one row in the permissions table
        /// </summary>
        /// <returns></returns>
        public Permission getPermissions()
        {
            return permDAO.getPermission();
        }
    }
}
