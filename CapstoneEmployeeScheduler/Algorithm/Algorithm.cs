using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneEmployeeScheduler.Model;
using System.Data;
using CapstoneEmployeeScheduler.Controllers;

namespace CapstoneEmployeeScheduler.Algorithm
{
    class Algorithm
    {
        User u = new User();
        UserController uc = new UserController();
        List<ScheduleElement> schedule = new List<ScheduleElement>();
        
        //THIS IS THE MAIN METHOD////////////////////////////////////////////////////////////////////////////////////////////////////
        public void makeSchedule()//probably not a void (used as placeholder)
        {
            List<User> users = uc.getAllUsers();
            /*foreach(User u in users)
            {
                
            }*/
            
            
        }
        //THIS IS THE MAIN METHOD /////////////////////////////////////////////////////////////////////////////////////////////////////



        public int readList(User user)//reads the user_roles list for a specific user
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
        /*
        public Role pickRole(User user)
        {
            Role role = new Role();
            List<Role> roles = user.Roles;
            int count = 0;
            readList(user);
            if (count == 0)
            {
                return null;
            }
            if (count == 1) //returns the only role
            {
                return roles[0]; 
            }
            if (count == 2) //alternates between two roles
            
            
        }*/
        public ScheduleElement createElement(User user, Role role)
        {
            ScheduleElement s = new ScheduleElement();
            s.user = user;
            s.role = role;
            return s;
        }
        public void addToSchedule(ScheduleElement s)//adds a user-role relationship to the element list
        {
            schedule.Add(s);
        }
        public List<ScheduleElement> showSchedule()//returns the list
        { 
            return schedule;
        }
        
    }
}
