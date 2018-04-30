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
using System.Data.SqlClient;
using CapstoneEmployeeScheduler.Views;
using CapstoneEmployeeScheduler.Models;
using CapstoneEmployeeScheduler.Controllers;
using CapstoneEmployeeScheduler.Algorithm;
using System.Threading;
using System.Windows.Threading;

namespace CapstoneEmployeeScheduler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new Views.HomePage();
            //con.Open();
        }
        
        private void Employees_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = new Views.Employees();
        }

        private void TestingBackend_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Views.TestingBackend();
        }

        private void Main_Navigated(object sender, NavigationEventArgs e)
        {
            // Not sure what this does, but taking it out crashes program
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = new Views.Roles();
        }

        private void History_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = new Views.History();
        }

        private void logout_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You have successfully logged out.", "Logout Successful");
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Under Construction. Please check back at a later time :)", "Generate Schedule");
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            //Based on our design, Generate schedule may have to be on its own page that we can name "Home"
            Main.Content = new Views.HomePage();
        }
        private void schedule_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Views.ShowSchedule();
        }

        private void NewEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (App.ISADMIN == false)
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                System.Windows.MessageBox.Show("Sorry! You do not have permission to create an employee", "Error", button, icon);
            }
            else
            {
                Main.Content = new Views.Employees();
                EmployeeModal m = new Views.EmployeeModal();
                m.ShowDialog();
            }
        }

        private void NewRole_Click(object sender, RoutedEventArgs e)
        {
            if (App.ISADMIN == false)
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                System.Windows.MessageBox.Show("Sorry! You do not have permission to create a role", "Error", button, icon);
            }
            else
            {
                Main.Content = new Views.Roles();
                RolesModal m = new Views.RolesModal();
                m.ShowDialog();
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            if (App.ISADMIN == false)
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                System.Windows.MessageBox.Show("Sorry! You do not have permission to edit an employee", "Error", button, icon);
            }
            else
            {
                Main.Content = new Views.HomePage();
                HomePage hp = new Views.HomePage();
                hp.GenerateButton_Click(null, null);
            }

        }

        private void ViewSchedule_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Views.ShowSchedule();
        }

        private void NewRolesRole_Click(object sender, RoutedEventArgs e)
        {
            if (App.ISADMIN == false)
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                System.Windows.MessageBox.Show("Sorry! You do not have permission to create a role", "Error", button, icon);
            }
            else
            {
                Main.Content = new Views.Roles();
                RolesModal m = new Views.RolesModal();
                m.ShowDialog();
            }
        }

        private void ViewRole_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Views.Roles();
        }

        private void NewEmployeesEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (App.ISADMIN == false)
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                System.Windows.MessageBox.Show("Sorry! You do not have permission to create an employee", "Error", button, icon);
            }
            else
            {
                Main.Content = new Views.Employees();
                EmployeeModal m = new Views.EmployeeModal();
                m.ShowDialog();
            }
        }

        private void ViewEmployees_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Views.Employees();
        }

        private void ExportEmployees_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Views.Employees();
            Employees em = new Views.Employees();
            em.CSVEButton_Click(null, null);
            
        }

        private void PrintSchedule_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Views.ShowSchedule();
            ShowSchedule ss = new Views.ShowSchedule();
            ss.PrintSButton_Click(null, null);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
      
        private void PrintEmployees_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Views.Employees();
            Employees em = new Views.Employees();
            em.PrintEButton_Click(null, null);
        }

      
        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            if (App.ISADMIN == false)
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                System.Windows.MessageBox.Show("Sorry! You do not have permission to edit an employee", "Error", button, icon);
            }
            else
            {
                Main.Content = new Views.admin();
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        /*private void FutureSchedules_click(object sender, RoutedEventArgs e)
        {
            /*for(int i=0; i < 10; i++)
            {
                ScheduleController sc = new ScheduleController();
                Schedule t = sc.getScheduleByDate(DateTime.Today);
                //this.pBar.Value = 20;
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
                //this.pBar.Value = 40;

                Schedule s = new Schedule();
                MakeSchedule ms = new MakeSchedule();
                List<User> users = new List<User>();
                UserController uc = new UserController();
                users = uc.getAllUsersWithRoleId();
                //this.pBar.Value = 60;
                List<int> rolecounts = new List<int>();
                int q;
                foreach (User u in users)
                {
                    q = u.Roles.Count();
                    rolecounts.Add(q);
                }
                //this.pBar.Value = 75;
                if (rolecounts.Contains(1))
                {
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxButton button = MessageBoxButton.OK;
                    System.Windows.MessageBox.Show("One or more employees are only trained in one role. This may cause scheudling problems", "Capstone Employee Scheduler", button, icon);
                }
                //this.pBar.Value = 80;
                ms.Generate(users);
                //this.pBar.Value = 100;
            }*/
        }
    }
