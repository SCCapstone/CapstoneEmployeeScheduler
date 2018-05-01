using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapstoneEmployeeScheduler.Models;
using CapstoneEmployeeScheduler.Controllers;
using CapstoneEmployeeScheduler.Algorithm;
using System.Threading;
using System.Windows.Threading;

namespace CapstoneEmployeeScheduler.Views
{
    /// <summary>
    /// Homepage contains the Generation buttons and loading bars for scheduling. The top button generates a single schedule for the current date, and
    /// checking for overwrites occurs here. We use our scheduleWindow() to display the schedule based on the date. The bottom button will perform
    /// the same general task as the top one, but instead runs the scheduling algorithm 7 times, and stores these schedules in the View Schedules page
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            
            
        }

        public void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            if (App.ISADMIN == false)
            {
                //If the user is not an admin, they are not allowed to create a schedule
                PermissionController pc = new PermissionController();
                Permission p = pc.getPermissions();
                if (p.GenerateSchedule == false)
                {
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;
                    System.Windows.MessageBox.Show("Sorry! You do not have permission to generate a schedule", "Error", button, icon);
                }
            }
            else
            {
                //Create a progress bar to track the progress of the schedule building
                System.Windows.Controls.ProgressBar pBar = new System.Windows.Controls.ProgressBar();
                pBar.Visibility = Visibility.Visible;
                
                ScheduleController sc = new ScheduleController();
                Schedule t = sc.getScheduleByDate(DateTime.Today);
                //Update the progress bar
                this.pBar.Value = 20;
                if (t.Id != null)
                {
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxButton button = MessageBoxButton.YesNo;
                    MessageBoxResult result = System.Windows.MessageBox.Show("There was already a schedule made today. Would you like to overwrite it?", "Capstone Employee Scheduler", button, icon);
                    if (result == MessageBoxResult.No)
                    {
                        return;
                    }
                    else if (result == MessageBoxResult.Yes)
                    {
                        //If they choose to overwrite the schedule, delete the old one
                        this.pBar.Value = 30;
                        sc.deleteSchedule(t.Id);
                    }

                }
                //Update the progress bar
                this.pBar.Value = 40;

                //Create a new schedule with all the users and roles in the database
                Schedule s = new Schedule();
                MakeSchedule ms = new MakeSchedule();
                List<User> users = new List<User>();
                UserController uc = new UserController();
                this.pBar.Value = 50;
                //Get all the users without roles beforehand to speed up scheduling process
                users = uc.getAllUsersWithRoleId();
                this.pBar.Value = 60;
                List<int> rolecounts = new List<int>();
                int q;
                foreach (User u in users)
                {
                    q = u.Roles.Count();
                    rolecounts.Add(q);
                }
                this.pBar.Value = 70;
              /*  if (rolecounts.Contains(1))
                {
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxButton button = MessageBoxButton.OK;
                    System.Windows.MessageBox.Show("One or more employees are only trained in one role. This may cause scheudling problems", "Capstone Employee Scheduler", button, icon);
                }
                */
                this.pBar.Value = 80;
                ms.Generate(users, DateTime.Today);
                this.pBar.Value = 100;
                //Display the schedule once it is generated
                ScheduleWindow x = new ScheduleWindow(DateTime.Today);
                x.ShowDialog();
                //Reset the progress bar
                this.pBar.Value = 0;
            }

        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            preGeneration x = new Views.preGeneration();
            x.Show();
        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //Do nothing
        }

        private void FutureSchedules_Click(object sender, RoutedEventArgs e)
        {
            //Create a progress bar to track the progress of the schedule building
            System.Windows.Forms.MessageBox.Show("Generating 7 schedules this may take a while.");
            System.Windows.Controls.ProgressBar futureBar = new System.Windows.Controls.ProgressBar();
            futureBar.Visibility = Visibility.Visible;
            List<User> users = new List<User>();
            UserController uc = new UserController();
            //Get all the users with the role ids before loop to speed up scheduling process
            users = uc.getAllUsersWithRoleId();
            //Create a new schedule 7 times
            for (int i=0; i < 7; i++)
            {
                ScheduleController sc = new ScheduleController();
                //View the 7 future schedules to see if any schedules have already been made that interfere with the weeks worth of schedules being generated.
                Schedule t = sc.getScheduleByDate(DateTime.Today.AddDays(i));
                this.futureBar.Value = 20;
                if (t.Id != null)
                {
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxButton button = MessageBoxButton.YesNo;
                    //Tells the user that the future schedules created will be overwritten
                    MessageBoxResult result = System.Windows.MessageBox.Show("There was already a schedule made today. All schedules already created will be overwritten.", "Capstone Employee Scheduler", button, icon);
                    if (result == MessageBoxResult.No)
                    {
                        return;
                    }
                    else if (result == MessageBoxResult.Yes)
                    {
                        //If they hit yes, delete the schedule
                        this.futureBar.Value = 30;
                        sc.deleteSchedule(t.Id);
                    }

                }
                Schedule s = new Schedule();
                s.ScheduleDate = DateTime.Today.AddDays(i);
                MakeSchedule ms = new MakeSchedule();
                //Update progress bar
                this.futureBar.Value = 50;
                /*List<int> rolecounts = new List<int>();
                int q;
                foreach (User u in users)
                {
                    q = u.Roles.Count();
                    rolecounts.Add(q);
                }
                this.futureBar.Value = 60;
               if (rolecounts.Contains(1))
                {
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxButton button = MessageBoxButton.OK;
                    System.Windows.MessageBox.Show("One or more employees are only trained in one role. This may cause scheudling problems", "Capstone Employee Scheduler", button, icon);
                }
                */
                this.futureBar.Value = 100;
                ms.Generate(users, DateTime.Today.AddDays(i));
                this.futureBar.Value = 0;
            }
        }
    }
}
