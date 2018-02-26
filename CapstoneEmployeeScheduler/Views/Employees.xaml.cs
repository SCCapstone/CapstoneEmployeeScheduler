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
using CapstoneEmployeeScheduler.Views;
using CapstoneEmployeeScheduler.Model;
using CapstoneEmployeeScheduler.Controllers;
namespace CapstoneEmployeeScheduler.Views
{
    /// <summary>
    /// Interaction logic for Employees.xaml
    /// </summary>
    public partial class Employees : Page
    {
        public Employees()
        {
            InitializeComponent();
            UserController u = new UserController();
            List<User> items = new List<User>();
            items = u.getAllUsers();
            Users.ItemsSource = items;

        }

        private void NewEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeModal m = new Views.EmployeeModal();
            m.ShowDialog();
            //Make button work with form
            InitializeComponent();
            UserController u = new UserController();
            List<User> items = new List<User>();
            items = u.getAllUsers();
            Users.ItemsSource = items;

        }

        private void EmployeeTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        /*private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            
            InitializeComponent();
            UserController u = new UserController();
            List<User> items = new List<User>();
            items = u.getAllUsers();
            Users.ItemsSource = items;
        }
        */

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            editEmployeeModal em = new Views.editEmployeeModal();

            em.ShowDialog();
        }

        private void Users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PrintEButton_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            if(printDlg.ShowDialog() == true)
            {
                printDlg.PrintVisual(Users, "List of Employees");
            }
        }
    }


}
