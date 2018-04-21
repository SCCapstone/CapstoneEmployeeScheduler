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
using CapstoneEmployeeScheduler.Models;
using CapstoneEmployeeScheduler.Controllers;
using System.Data;

namespace CapstoneEmployeeScheduler.Views
{
    /// <summary>
    /// Interaction logic for editEmployeeModal.xaml
    /// </summary>
    public partial class editEmployeeModal : Window
    {
        private int passedID;
        UserController uc = new UserController();
        User user;

        public editEmployeeModal(int id)
        {
            InitializeComponent();
            //Gets the ID of the User that is being edited
            passedID = id;
            user = uc.getUserById(passedID);

            //Fills the boxes with values already in database
            name.Text = user.userName;
            email.Text = user.email;
            ShiftBox.Text = user.shift;
            user.OutOfWork = false;
            if(user.Disabled == true)
            {
                isDisabled.IsChecked =  true;
            }
            if(user.Admin == true)
            {
                isAdmin.IsChecked = true;
            }
            //if(user.OutOfWork == true)
            //{
            //    isOutofWork.IsChecked = true;
            //}
            //Displays role that are able to be selected
            List<Role> items = new List<Role>();
            RoleController r = new RoleController();
            items = r.getAllRoles();
            roleList.ItemsSource = items;
            
            //Pre-select the roles that the User already has
            for (int k = 0; k < roleList.Items.Count; k++)
            {
                Role aRole = (Role) roleList.Items[k];
                if (user.Roles.Any(rol => rol.Id == aRole.Id))
                {
                    roleList.SelectedItems.Add(roleList.Items[k]);
                }
            }
        } 

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            //Once the submit button is selected, update database values
            List<User> userList = new List<User>();
            userList = uc.getAllUsersWithoutRoles();
            Boolean isTaken = false;
            //Check to see if any of the boxes are empty. If any are, throw a warning and don't let them proceed
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
                //Check to make sure the employee isn't already in the database
                foreach (User u in userList)
                {
                    if (name.Text.Equals(u.userName))
                    {
                        if (u.Id == passedID)
                        {
                            //It is the one being edited, so we are still good
                        }
                        else
                        {
                            MessageBoxButton button = MessageBoxButton.OK;
                            MessageBoxImage icon = MessageBoxImage.Error;
                            System.Windows.MessageBox.Show("This name has already been entered in the database", "Error", button, icon);
                            //Can't have the same name as someone already there
                            isTaken = true;
                        }
                    }
                    else if (email.Text.Equals(u.email))
                    {
                        if (u.Id == passedID)
                        {
                            //It is the one being edited, so we are still good
                        }
                        else
                        {
                            MessageBoxButton button = MessageBoxButton.OK;
                            MessageBoxImage icon = MessageBoxImage.Error;
                            System.Windows.MessageBox.Show("This email has already been entered in the database", "Error", button, icon);
                            //Can't have the same email as someone already there
                            isTaken = true;
                        }
                    }
                }
                if (isTaken == true)
                {
                    //If there is a same value, don't add to the database
                }
                else
                {
                    //We are sure there are no duplicates so update the employee
                    user.UserName = name.Text;
                    user.Email = email.Text;
                    user.Shift = ShiftBox.Text;

                    //if (isOutofWork.IsChecked == true)
                    //{
                    //    //If checkbox for out of work is true, set field
                    //    user.OutOfWork = true;
                    //}
                    //else
                    //{
                    //    user.OutOfWork = false;
                    //}
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

                    //Add each role selected to that employee
                    List<Role> listItems = new List<Role>();
                    foreach (Role role in roleList.SelectedItems)
                    {
                        listItems.Add(role);
                    }
                    //The user must have at least one role before proceeding
                    if (listItems.Count == 0)
                    {
                        MessageBoxButton button = MessageBoxButton.OK;
                        MessageBoxImage icon = MessageBoxImage.Stop;
                        System.Windows.MessageBox.Show("Employee Must be assigned at least one role!", "Capstone Employee Scheduler", button, icon);
                        return;
                    }
                    user.Roles = listItems;
                    uc.editUser(user);
                    MessageBox.Show("Edit Successful!", "Edit Successful");
                    this.Close();
                }
            }
        }

        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Nothing goes here
        }

        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Nothing goes here
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Nothing goes here
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
