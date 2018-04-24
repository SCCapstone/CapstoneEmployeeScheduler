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
            //Progress Indicator
            //Currently only runs for 10 seconds then quits
            //We can set it to quit once the schedule is generated
           
            //ProgressIndicator.IsBusy = true;
            //ProgressIndicator.BusyContent = string.Format("Generating Schedule...");
            //System.Windows.MessageBox.Show("Starting schedule building process");

            /*
            Task.Factory.StartNew(() =>
                {
                    for(int i=0; i<10; i++)
                    {
                        Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                        {
                            ProgressIndicator.BusyContent = string.Format("generating schedule");
                        }));
                        Thread.Sleep(1000);
                    }
                }
            ).ContinueWith((task) =>
                {
                    ProgressIndicator.IsBusy = false;
                }, TaskScheduler.FromCurrentSynchronizationContext()
            );*/


            ScheduleController sc = new ScheduleController();
            Schedule t = sc.getScheduleByDate(DateTime.Today);
            if (t.Id != null)
            {
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxResult result = System.Windows.MessageBox.Show("There was already a schedule made today. Would you like to overwrite it?","Capstone Employee Scheduler", button,icon);
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

            
            Schedule s = new Schedule();
            MakeSchedule ms = new MakeSchedule();
            List<User> users = new List<User>();
            UserController uc = new UserController();
            users = uc.getAllUsersWithRoleId();
            List<int> rolecounts = new List<int>();
            int q;
            foreach (User u in users)
            {
                q = u.Roles.Count();
                rolecounts.Add(q);
            }
            if (rolecounts.Contains(1))
            {
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxButton button = MessageBoxButton.OK;
                System.Windows.MessageBox.Show("One or more employees are only trained in one role. This may cause scheudling problems", "Capstone Employee Scheduler", button, icon);
            }
            ms.Generate(users);
            //ProgressIndicator.IsBusy = false;
            //System.Windows.MessageBox.Show("Loading screen should be done and schedule should appear");
            //Thread.Sleep(1000);

            ScheduleWindow x = new ScheduleWindow();
            x.ShowDialog();
            
        }

       /* private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            Content = new Views.ShowSchedule();
        }
        */
        private void test_Click(object sender, RoutedEventArgs e)
        {
            preGeneration x = new Views.preGeneration();
            x.Show();
        }
    }
}
