//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using CapstoneEmployeeScheduler.Model;
//using System.Data;
//using CapstoneEmployeeScheduler.Controllers;

//namespace CapstoneEmployeeScheduler.Algorithm
//{
//    class Algorithm
//    {
//        User u = new User();
//        UserController uc = new UserController();
//        List<ScheduleElement> schedule = new List<ScheduleElement>();
        
//        //THIS IS THE MAIN METHOD////////////////////////////////////////////////////////////////////////////////////////////////////
//        public void makeSchedule()//probably not a void (used as placeholder)
//        {
//            List<User> users = uc.getAllUsers();
            
//            foreach (User u in users)
//            {
//                if (u.Disabled == false)
//                {
//                    //do scheduling things
//                }
//            }
            
         
//        }
        
//        //THIS IS THE MAIN METHOD /////////////////////////////////////////////////////////////////////////////////////////////////////

//        public static void Shuffle(int[] array)//Fisher-Yates method for shuffling (Using to make sure roles dont repeat)
//        {
//            Random r = new System.Random();
//            int n = array.Length;
//            while (n > 1)
//            {
//                int k = r.Next(n--);
//                int temp = array[n];
//                array[n] = array[k];
//                array[k] = temp;
//            }
//        }

//        public int readList(User user)//reads the user_roles list for a specific user
//        {
//            List<Role> roles = user.Roles;
//            int count = 0;
//            foreach (Role r in roles)
//            {
//                count++;
//            }
//            if (count == 0)
//            {
//                System.Console.WriteLine("Error: Employee has no assigned roles,cannot schedule");//TODO: Add error codes
//                return count;
//            }
//            else if (count == 1)
//            {
//                System.Console.WriteLine("Warning: Employee is only trained in one role");
//                return count;
//            }
//            else
//            {
//                return count;
//            }

//        }
        
//        public Role pickRole(User user)
//        {
//            int? role1 = user.RoleOneDayAgo;
//            int? role2 = user.RoleTwoDaysAgo;
//            int? role3 = user.RoleThreeDaysAgo;
//            int roleNum = 0;
//            List<Role> roles = user.Roles;
//            List<int> roleNums = new List<int>();
//            int count = readList(user);
//            foreach (Role r in roles)
//            {
//                roleNums.Add(r.Id); 
//            }

//            if (count == 0)
//            {
//                return null;
//            }
//            //TODO: Convert each instance of roles[n] to roleNums[n], make sure they interact correctly with the new lists
//            else if (count == 1) //returns the only role
//            {
//                return roles[0]; 
//            }
//            else if (count == 2) //alternates between two roles
//            {
//                if (role1 == roleNums[0])//update roles (helper function)
//                {
//                    return roles[1];
//                }
//                else
//                {
//                    return roles[0];
//                }
//            }
//            else if (count == 3)
//            {
//                Random r = new System.Random();
//                var array = new int[] { 0, 1, 2 };

//                if (user.RoleOneDayAgo == roles[0])//Shuffling should assure that the role at the same position in the array is not the same
//                {
//                    Shuffle(array);
//                    return roles[0];
//                }
//                else if (user.RoleOneDayAgo == roles[1])
//                {
//                    Shuffle(array);
//                    return roles[1];
//                }
//                else if (user.RoleOneDayAgo == roles[2])
//                {
//                    Shuffle(array);
//                    return roles[2];
//                }
//            }
//            else if (count == 4)
//            {
//                Random r = new System.Random();
//                var array = new int[] { 0, 1, 2, 3 };

//                if (user.RoleOneDayAgo == roles[0])
//                {
//                    Shuffle(array);
//                    return roles[0];
//                }
//                else if (user.RoleOneDayAgo == roles[1])
//                {
//                    Shuffle(array);
//                    return roles[1];
//                }
//                else if (user.RoleOneDayAgo == roles[2])
//                {
//                    Shuffle(array);
//                    return roles[2];
//                }
//                else if (user.RoleOneDayAgo == roles[3])
//                {
//                    Shuffle(array);
//                    return roles[3];
//                }
//                if (user.RoleTwoDaysAgo == roles[0])
//                {
//                    Shuffle(array);
//                    return roles[0];
//                }
//                else if (user.RoleTwoDaysAgo == roles[1])
//                {
//                    Shuffle(array);
//                    return roles[1];
//                }
//                else if (user.RoleTwoDaysAgo == roles[2])
//                {
//                    Shuffle(array);
//                    return roles[2];
//                }
//                else if (user.RoleTwoDaysAgo == roles[3])
//                {
//                    Shuffle(array);
//                    return roles[3];
//                }
//            }
//            else
//            {
//                Random r = new System.Random();
//                int val = r.Next(0, count);
//                var array = new int[count];
//                for (int i = 0; i<count; i++)
//                {
//                    array[i] = i;
//                }
//                if (user.RoleOneDayAgo == roles[val] || user.RoleTwoDaysAgo == roles[val] || user.RoleThreeDaysAgo == roles[val])
//                {
//                    Shuffle(array);
//                    return roles[array[val]];
//                }
//                else
//                {
//                    return roles[array[val]];
//                }
//            }
//            return roles[0];
//        }

//        public ScheduleElement createElement(User user, Role role)
//        {
//            ScheduleElement s = new ScheduleElement();
//            s.user = user;
//            s.role = role;
//            return s;
//        }

//        public void addToSchedule(ScheduleElement s)//adds a user-role relationship to the element list
//        {
//            schedule.Add(s);
//        }

//        public List<ScheduleElement> showSchedule()//returns the list
//        { 
//            return schedule;
//        }
        
//    }
//}
