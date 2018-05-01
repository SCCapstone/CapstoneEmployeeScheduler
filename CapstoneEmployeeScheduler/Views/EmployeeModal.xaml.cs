using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CapstoneEmployeeScheduler.Controllers;
using CapstoneEmployeeScheduler.DAO;
using CapstoneEmployeeScheduler.Models;
using System.Data;

namespace CapstoneEmployeeScheduler.Views
{
    /// <summary>
    /// Interaction logic for EmployeeModal.xaml
    /// </summary>
    public partial class EmployeeModal : Window
    {
        public EmployeeModal()
        {
            InitializeComponent();
            RoleController rc = new RoleController();
            List<Role> items = new List<Role>();
            roleListBox.ItemsSource = rc.getAllRoles();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Closes the modal if they hit close
            this.Close();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            //Method ran when the user tries to submit the new Employee
            UserController uc = new UserController();
            User user = new User();
            //Get list of Users already in table so we don't have a duplicate name
            List<User> userList = new List<User>();
            userList = uc.getAllUsersWithoutRoles();
            RoleController rc = new RoleController();
            Boolean isTaken = false;
            //Check to see if any fields are empty. If they are, throw an error and don't let them proceed
            if (name.Text.Equals(""))
            {

                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                System.Windows.MessageBox.Show("The name field is empty. Please enter a name for the user", "Error", button, icon);
            }
            else if (email.Text.Equals(""))
            {

                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                System.Windows.MessageBox.Show("The email field is empty. Please enter an email for the user", "Error", button, icon);
            }
            else if (ShiftBox.Text.Equals(""))
            {

                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                System.Windows.MessageBox.Show("The shift field is empty. Please select night or day shift", "Error", button, icon);
            }
            else
            {
                //Check Name and email versus all users already in the table. If they are, don't let them proceed
                foreach(User u in userList)
                {
                    if(name.Text.Equals(u.userName))
                    {
                        MessageBoxButton button = MessageBoxButton.OK;
                        MessageBoxImage icon = MessageBoxImage.Error;
                        System.Windows.MessageBox.Show("This name has already been entered in the database", "Error", button, icon);
                        //Keep track of if it is taken
                        isTaken = true;
                    }
                    else if (email.Text.Equals(u.email))
                    {
                        MessageBoxButton button = MessageBoxButton.OK;
                        MessageBoxImage icon = MessageBoxImage.Error;
                        System.Windows.MessageBox.Show("This email has already been entered in the database", "Error", button, icon);
                        //Keep track of if it is taken
                        isTaken = true;
                    }
                }
                if (isTaken == true)
                {
                    //If it is taken, don't add it until they change it
                }
                else
                {
                    //It isn't taken, so we can add it!
                    user.UserName = name.Text;
                    user.Email = email.Text;
                    user.Shift = ShiftBox.Text;
                    user.OutOfWork = false;
    
                    if (isDisabled.IsChecked == true)
                    {
                        //If checkbox for disabled is true, set field
                        user.Disabled = true;
                    }
                    else
                    {
                        user.Disabled = false;
                    }
                    if (isAdmin.IsChecked == true)
                    {
                        //If checkbox for admin is true, set field
                        user.Admin = true;
                    }
                    else
                    {
                        user.Admin = false;
                    }

                    user.Password = " ";
                    //Create a list to keep track of all the Roles they selected for their employee
                    List<Role> listItems = new List<Role>();
                    foreach (Role role in roleListBox.SelectedItems)
                    {
                        listItems.Add(role);
                    }
                    //If they don't select one, force them to
                    if (listItems.Count == 0)
                    {
                        MessageBoxButton button = MessageBoxButton.OK;
                        MessageBoxImage icon = MessageBoxImage.Stop;
                        System.Windows.MessageBox.Show("Employee Must be assigned at least one role!", "Capstone Employee Scheduler", button, icon);
                        return;
                    }
                    //Assign the roles to the User and call the createUser method to finish adding them
                    user.Roles = listItems;
                    uc.createUser(user);
                    int userId = user.Id;
                    //Close the popup
                    this.Close();
                }
            }
        }

        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Nothing goes here
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Nothing goes here
        }

        private void roleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Nothing goes here
        }
    }
}
