using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneEmployeeScheduler.Model
{
    class User
    {
        private int id;
        public string userName;
        public string email;
        public string shift;
        private Role roleOneDayAgo = null;
        private Role roleTwoDaysAgo = null;
        private Role roleThreeDaysAgo = null;
        private bool outOfWork;
        private bool disabled;
        private bool admin;
        private string password;
        private List<Role> roles;

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

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Shift
        {
            get
            {
                return shift;
            }

            set
            {
                shift = value;
            }
        }

        public Role RoleOneDayAgo
        {
            get
            {
                return roleOneDayAgo;
            }

            set
            {
                roleOneDayAgo = value;
            }
        }

        public Role RoleTwoDaysAgo
        {
            get
            {
                return roleTwoDaysAgo;
            }

            set
            {
                roleTwoDaysAgo = value;
            }
        }

        public Role RoleThreeDaysAgo
        {
            get
            {
                return roleThreeDaysAgo;
            }

            set
            {
                roleThreeDaysAgo = value;
            }
        }

        public bool OutOfWork
        {
            get
            {
                return outOfWork;
            }

            set
            {
                outOfWork = value;
            }
        }

        public bool Disabled
        {
            get
            {
                return disabled;
            }

            set
            {
                disabled = value;
            }
        }

        public bool Admin
        {
            get
            {
                return admin;
            }

            set
            {
                admin = value;
            }
        }

        public List<Role> Roles
        {
            get
            {
                return roles;
            }

            set
            {
                roles = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }
    }
}
