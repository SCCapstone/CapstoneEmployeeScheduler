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
    /// Interaction logic for HomePage.xaml
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

                System.Windows.Controls.ProgressBar pBar = new System.Windows.Controls.ProgressBar();
                pBar.Visibility = Visibility.Visible;


                ScheduleController sc = new ScheduleController();
                Schedule t = sc.getScheduleByDate(DateTime.Today);
                this.pBar.Value = 20;
                if (t.Id != null)
                {
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxButton button = MessageBoxButton.YesNo;
                    MessageBoxResult result = System.Windows.MessageBox.Show("There was already a schedule made today. Would you like to overwrite it?", "Capstone Employee Scheduler", button, icon);
                    if (result == MessageBoxResult.No)
                    {
                        //ProgressIndicator.IsBusy = false;
                        return;
                    }
                    else if (result == MessageBoxResult.Yes)
                    {
                        sc.deleteSchedule(t.Id);
                    }

                }
                this.pBar.Value = 40;

                Schedule s = new Schedule();
                MakeSchedule ms = new MakeSchedule();
                List<User> users = new List<User>();
                UserController uc = new UserController();
                users = uc.getAllUsersWithRoleId();
                this.pBar.Value = 60;
                List<int> rolecounts = new List<int>();
                int q;
                foreach (User u in users)
                {
                    q = u.Roles.Count();
                    rolecounts.Add(q);
                }
                this.pBar.Value = 75;
                /*if (rolecounts.Contains(1))
                {
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxButton button = MessageBoxButton.OK;
                    System.Windows.MessageBox.Show("One or more employees are only trained in one role. This may cause scheduling problems", "Capstone Employee Scheduler", button, icon);
                }
                */
                this.pBar.Value = 80;
                ms.Generate(users, DateTime.Today);
                this.pBar.Value = 100;
                ScheduleWindow x = new ScheduleWindow(DateTime.Today);
                x.ShowDialog();
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
            List<User> users = new List<User>();
            UserController uc = new UserController();
            users = uc.getAllUsersWithRoleId();
         
            for (int i=0; i < 7; i++)
            {
                ScheduleController sc = new ScheduleController();
                Schedule t = sc.getScheduleByDate(DateTime.Today.AddDays(i));//view the 7 future schedules to see if any schedules have already been made that interfere with the weeks worth of schedules being generated.
                //this.pBar.Value = 20;
                if (t.Id != null)
                {
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxButton button = MessageBoxButton.YesNo;
                    MessageBoxResult result = System.Windows.MessageBox.Show("There was already a schedule made today. All schedules already created will be overwritten.", "Capstone Employee Scheduler", button, icon);
                    if (result == MessageBoxResult.No)
                    {
                        //ProgressIndicator.IsBusy = false;
                        return;
                    }
                    else if (result == MessageBoxResult.Yes)
                    {
                        sc.deleteSchedule(t.Id);
                    }

                }
                //this.pBar.Value = 40;

                Schedule s = new Schedule();
                s.ScheduleDate = DateTime.Today.AddDays(i);
                MakeSchedule ms = new MakeSchedule();
                //List<User> users = new List<User>();
                //UserController uc = new UserController();
                //users = uc.getAllUsersWithRoleId();
                //this.pBar.Value = 60;
                List<int> rolecounts = new List<int>();
                int q;
                foreach (User u in users)
                {
                    q = u.Roles.Count();
                    rolecounts.Add(q);
                }
                //this.pBar.Value = 75;
                /*if (rolecounts.Contains(1))
                {
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxButton button = MessageBoxButton.OK;
                    System.Windows.MessageBox.Show("One or more employees are only trained in one role. This may cause scheudling problems", "Capstone Employee Scheduler", button, icon);
                }*/
                //this.pBar.Value = 80;
                ms.Generate(users, DateTime.Today.AddDays(i));//here pass in 2nd argument
                //ms.Generate(users, );
                //this.pBar.Value = 100;
            }
        }
    }
}
