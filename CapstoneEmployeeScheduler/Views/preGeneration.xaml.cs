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
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using CapstoneEmployeeScheduler.Algorithm;
using CapstoneEmployeeScheduler.Controllers;
using CapstoneEmployeeScheduler.Models;
namespace CapstoneEmployeeScheduler.Views

{
    /// <summary>
    /// Interaction logic for preGeneration.xaml
    /// </summary>
    public partial class preGeneration : Window
    {
        public preGeneration()
        {
            InitializeComponent();
            RoleController r = new RoleController();
            List<Role> item = new List<Role>();
            item = r.getAllRoles();
            Role.ItemsSource = item;
        }
        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel?", "Capstone Employee Scheduler", button, icon);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }

        }

        private void start_Click(object sender, RoutedEventArgs e)//this will generate the schedule with the given numbers for each role
        {
            /*
            ScheduleController sc = new ScheduleController();
            if (sc.getScheduleByDate(DateTime.Today).Id != null)
            {
                System.Windows.MessageBox.Show("There was already a schedule made today.");
            }


            Schedule s = new Schedule();
            MakeSchedule ms = new MakeSchedule();
            List<User> users = new List<User>();
            UserController uc = new UserController();
            users = uc.getAllUsersWithRoleId();
            ms.Generate(users);
            Content = new Views.ShowSchedule();
            */
            
        }

        private void role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Count_TextChanged(object sender, RoutedEventArgs e)
        {
            Role r = (Role)Role.SelectedItem;
            var binding = ((TextBox)sender).GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
            
        }

        
    }
}
