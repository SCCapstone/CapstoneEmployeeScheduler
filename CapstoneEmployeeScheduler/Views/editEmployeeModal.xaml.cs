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

            //Fills the boxes with values already in database
            InitializeComponent();
            passedID = id;
            user = uc.getUserById(passedID);
            
            name.Text = user.userName;
            email.Text = user.email;
            ShiftBox.Text = user.shift;
            if(user.Disabled == true)
            {
                isDisabled.IsChecked =  true;
            }
            if(user.Admin == true)
            {
                isAdmin.IsChecked = true;
            }
            if(user.OutOfWork == true)
            {
                isOutofWork.IsChecked = true;
            }
            //displays role that are able to be selected
            List<Role> items = new List<Role>();
            RoleController r = new RoleController();
            items = r.getAllRoles();
            roleList.ItemsSource = items;
            //items = r.getAllRoles();
            //roleList.ItemsSource = items;
            // foreach (Role role in user.Roles)
            //    {
            //MessageBox.Show("Selected Role: " + role.RoleName);
            //    roleList.SelectedItems.Add(role);
            //  }

            //roleList.SelectedItems.Add(roleList.Items[1]);
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
            //Once the submit button is selected, updates database values
            List<User> userList = new List<User>();
            userList = uc.getAllUsersWithoutRoles();
            Boolean isTaken = false;
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
                foreach (User u in userList)
                {
                    if (name.Text.Equals(u.userName))
                    {
                        if (u.Id == passedID)
                        {
                            //it is the one being edited
                        }
                        else
                        {
                            MessageBoxButton button = MessageBoxButton.OK;
                            MessageBoxImage icon = MessageBoxImage.Error;
                            System.Windows.MessageBox.Show("This name has already been entered in the database", "Error", button, icon);
                            isTaken = true;
                        }
                    }
                    else if (email.Text.Equals(u.email))
                    {
                        if (u.Id == passedID)
                        {
                            //it is the one being edited
                        }
                        else
                        {
                            MessageBoxButton button = MessageBoxButton.OK;
                            MessageBoxImage icon = MessageBoxImage.Error;
                            System.Windows.MessageBox.Show("This email has already been entered in the database", "Error", button, icon);
                            isTaken = true;
                        }
                    }
                }
                if (isTaken == true)
                {
                    //dont add
                }
                else
                {

                    user.UserName = name.Text;
                    user.Email = email.Text;

                    user.Shift = ShiftBox.Text;
                    if (isOutofWork.IsChecked == true)
                    {
                        //if checkbox for disabled is true, set field
                        user.OutOfWork = true;
                    }
                    else
                    {
                        user.OutOfWork = false;
                    }
                    if (isDisabled.IsChecked == true)
                    {
                        //if checkbox for disabled is true, set field
                        user.Disabled = true;
                    }
                    else
                    {
                        user.Disabled = false;
                    }
                    if (isAdmin.IsChecked == true)
                    {
                        //if checkbox for disabled is true, set field
                        user.Admin = true;
                    }
                    else
                    {
                        user.Admin = false;
                    }
                    user.Password = " ";

                    List<Role> listItems = new List<Role>();
                    foreach (Role role in roleList.SelectedItems)
                    {
                        listItems.Add(role);
                    }
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
            //Not sure what this does, but the application crashes without this method for some reason ¯\_(ツ)_/¯
        }

        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Not sure what this does, but the application crashes without this method for some reason ¯\_(ツ)_/¯
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Not sure what this does, but the application crashes without this method for some reason ¯\_(ツ)_/¯
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
