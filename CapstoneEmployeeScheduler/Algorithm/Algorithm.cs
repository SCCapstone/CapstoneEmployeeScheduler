using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneEmployeeScheduler.Model;
using System.Data;
using CapstoneEmployeeScheduler.Controllers;
using CapstoneEmployeeScheduler.Models;

namespace CapstoneEmployeeScheduler.Algorithm
{
    class Algorithm
    {

        User u = new User();
        Schedule s = new Schedule();
        //UserController uc = new UserController();
        ScheduleController sc = new ScheduleController();
        
       

        //THIS IS THE MAIN METHOD////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Generate(List<User> users)
        {
            foreach (User u in users)
            {
                if (u.Disabled == false)
                {
                    int roleid = pickRole(u);
                    addToSchedule(u, roleid);
                }
            }

            sc.createSchedule(s);
            
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
                System.Console.WriteLine("Error: Employee has no assigned roles,cannot schedule");//TODO: Add error codes
                return count;
            }
            else if (count == 1)
            {
                System.Console.WriteLine("Warning: Employee is only trained in one role");
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

    }
}
