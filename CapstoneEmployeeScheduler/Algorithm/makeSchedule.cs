﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneEmployeeScheduler.Models;
using System.Data;
using CapstoneEmployeeScheduler.Controllers;
using System.Windows;

namespace CapstoneEmployeeScheduler.Algorithm
{
    class MakeSchedule
    {

        User u = new User();
        Role r = new Role();
        Schedule s = new Schedule();
        //UserController uc = new UserController();
        RoleController rc = new RoleController();
        ScheduleController sc = new ScheduleController();

       

        //THIS IS THE MAIN METHOD////////////////////////////////////////////////////////////////////////////////////////////////////
        public Schedule Generate(List<User> users)
        {

            int roleid;
            int count;
            //int priority;
            foreach (User u in users)
            {
                
                if (u.Disabled == false)
                {
                    Start: roleid = pickRole(u);
                    
                    count = checkCount(rc.getRoleById(roleid));//check to see if there are still spots open for that role
                    if (count > 0)
                    {
                        
                        addToSchedule(u, roleid);//add role/user pair to the schedule
                        updateRole(u, roleid);//used for next day scheduling
                        count--;//take one spot away from the role
                    }
                    else if (count == 0)
                    {
                        goto Start;//possibly find a better way to do this.
                    }
                }
            }

            sc.createSchedule(s);//add schedule to the database
            return s;
            
        }

        //THIS IS THE MAIN METHOD /////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void Shuffle(int[] array)//Fisher-Yates method for shuffling (Using to make sure roles dont repeat)
        {
            Random r = new System.Random();
            int n = array.Length;
            while (n > 1)
            {
                int k = r.Next(n--);
                int temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
       
        private int readList(User user)//reads the user_roles list for a specific user
        {
            List<Role> roles = user.Roles;
            int count = 0;
            foreach (Role r in roles)
            {
                count++;
            }
            if (count == 0)
            {
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBox.Show("Error: " + user.UserName + " has no assigned roles,cannot schedule. Application must exit.","Capstone Employee Scheduler",button,icon);
                Environment.Exit(0);
                return 0;
            }
            else if (count == 1)
            {
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBox.Show("Warning: "+user.userName + " is only trained in one role. This may cause scheduling issues", "Capstone Employee Scheduler",button,icon);
                return count;
            }
            else
            {
                return count;
            }

        }

        private int pickRole(User user)
        {
            int? role1 = user.RoleOneDayAgo;
            int? role2 = user.RoleTwoDaysAgo;
            int? role3 = user.RoleThreeDaysAgo;
            //int priority = 1;
            //int roleNum = 0;
            List<Role> roles = user.Roles;
            List<int> roleNums = new List<int>();
            int count = readList(user);
            foreach (Role r in roles)
            {
                roleNums.Add(r.Id);
            }

            if (count == 0)
            {
                return 0;
            }

            else if (count == 1) //returns the only role
            {
                return roleNums[0];
            }
            else if (count == 2) //alternates between two roles
            {
                if (role1 == roleNums[0])//update roles (helper function)
                {
                    return roleNums[1];
                }
                else
                {
                    return roleNums[0];
                }
            }
            else if (count == 3)
            {
                Random r = new System.Random();
                var array = new int[] { 0, 1, 2 };

                if (role1 == roleNums[0])//Shuffling should assure that the role at the same position in the array is not the same
                {
                    Shuffle(array);
                    return roleNums[0];
                }
                else if (role1 == roleNums[1])
                {
                    Shuffle(array);
                    return roleNums[1];
                }
                else if (role1 == roleNums[2])
                {
                    Shuffle(array);
                    return roleNums[2];
                }
            }
            else if (count == 4)
            {
                Random r = new System.Random();
                var array = new int[] { 0, 1, 2, 3 };

                if (role1 == roleNums[0])
                {
                    Shuffle(array);
                    return roleNums[0];
                }
                else if (role1 == roleNums[1])
                {
                    Shuffle(array);
                    return roleNums[1];
                }
                else if (role1 == roleNums[2])
                {
                    Shuffle(array);
                    return roleNums[2];
                }
                else if (role1 == roleNums[3])
                {
                    Shuffle(array);
                    return roleNums[3];
                }
                if (role2 == roleNums[0])
                {
                    Shuffle(array);
                    return roleNums[0];
                }
                else if (role2 == roleNums[1])
                {
                    Shuffle(array);
                    return roleNums[1];
                }
                else if (role2 == roleNums[2])
                {
                    Shuffle(array);
                    return roleNums[2];
                }
                else if (role2 == roleNums[3])
                {
                    Shuffle(array);
                    return roleNums[3];
                }
            }
            else
            {
                Random r = new System.Random();
                int val = r.Next(0, count);
                var array = new int[count];
                for (int i = 0; i < count; i++)
                {
                    array[i] = i;
                }
                if (role1 == roleNums[val] || role2 == roleNums[val] || role3 == roleNums[val])
                {
                    Shuffle(array);
                    return roleNums[array[val]];
                }
                else
                {
                    return roleNums[array[val]];
                }
            }
            
            return roleNums[0];
        }

        private void addToSchedule(User user, int roleId)
        {
           s.UserRoles.Add(user.Id, roleId);
        }

        public Dictionary<int, int> showSchedule()//returns the list
        {
            return s.UserRoles;
        }
        private void updateRole(User user,int roleID)//add the current role and shift everything back one day
        {
            user.RoleThreeDaysAgo = user.RoleTwoDaysAgo;
            user.RoleTwoDaysAgo = user.RoleOneDayAgo;
            user.RoleOneDayAgo = roleID;
        }
        public int checkCount(Role r)
        {
            return r.RoleCount;
        }
    }
    
}
