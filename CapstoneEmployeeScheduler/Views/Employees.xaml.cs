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
            //code to display the table with all the employees
            InitializeComponent();
            ShowTable();
        }

        private void NewEmployee_Click(object sender, RoutedEventArgs e)
        {
            //calls popup to create a new employee
            EmployeeModal m = new Views.EmployeeModal();
            m.ShowDialog();
            InitializeComponent();
            ShowTable();
        }

        private void EmployeeTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Not sure what this method does, but the application crashes without this method for some reason ¯\_(ツ)_/¯
        }

        public void ShowTable()
        {
            //method to show the table of users and email.
            UserController u = new UserController();
            List<User> items = new List<User>();
            items = u.getAllUsers();
            Users.ItemsSource = items;
        }
        

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            //This method is called when the edit button is pressed on one of the employees
            //need a way to autofill the text boxes and overwrite instead of doing nothing.
            //var item = Users.Items.GetItemAt(Users.SelectedIndex);
            //MessageBox.Show(item.ToString());

            //string type = Users.SelectedItem.GetType().ToString();
            //MessageBox.Show(type);

            User u= (User) Users.SelectedItem;
            int id = u.Id;
            editEmployeeModal em = new Views.editEmployeeModal(id);
            em.ShowDialog();
            ShowTable();
        }

        private void Users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Not sure what this does, but the application crashes without this method for some reason ¯\_(ツ)_/¯
            if (Users.SelectedIndex >= 0)
            {
                
            }
        }

        private void PrintEButton_Click(object sender, RoutedEventArgs e)
        {
            //method for printing table of employees
            //TODO: once schedule is able to be displayed, move to schedule
            PrintDialog printDlg = new PrintDialog();
            if(printDlg.ShowDialog() == true)
            {
                printDlg.PrintVisual(Users, "List of Employees");
            }
        }

    }


}
