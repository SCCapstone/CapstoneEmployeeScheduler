﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneEmployeeScheduler.Model
{
    class User
    {
        private int id;
        private string userName;
        private string email;
        private string shift;
        private int roleOneDayAgo;
        private int roleTwoDaysAgo;
        private int roleThreeDaysAgo;
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

        public int RoleOneDayAgo
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

        public int RoleTwoDaysAgo
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

        public int RoleThreeDaysAgo
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

        internal List<Role> Roles
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
