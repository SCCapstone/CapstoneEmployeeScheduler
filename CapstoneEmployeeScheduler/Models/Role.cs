using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneEmployeeScheduler.Models
{
    class Role
    {
        private int id;
        private string roleName;
        private string roleDescription;
        private int roleCount;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string RoleName
        {
            get
            {
                return roleName;
            }

            set
            {
                roleName = value;
            }
        }

        public string RoleDescription
        {
            get
            {
                return roleDescription;
            }

            set
            {
                roleDescription = value;
            }
        }

        public int RoleCount
        {
            get
            {
                return roleCount;
            }
            
            set
            {
                roleCount = value;
            }
        }
    }
}
