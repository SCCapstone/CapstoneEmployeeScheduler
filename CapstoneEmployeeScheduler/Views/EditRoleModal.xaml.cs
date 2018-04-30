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

namespace CapstoneEmployeeScheduler.Views
{
    /// <summary>
    /// Takes in role id and populates modal with current values associated with it. After submitting, the values update the SQL tables
    /// for the role in question.
    /// </summary>
    public partial class EditRoleModal : Window
    {
        public string des;
        private int passedID;
        Role role = new Role();
        RoleController rc = new RoleController();

        public EditRoleModal(int id)
        {
            InitializeComponent();
            //Get the ID of the role that is being edited
            passedID = id;
            role = (Role)rc.getRoleById(passedID);
            //Fills the boxes with values already in database
            name.Text = role.RoleName;
            description.Text = role.RoleDescription;
            RoleCountBox.Text = role.RoleCount.ToString();
            role.RoleDescription = description.Text;
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            Boolean isTaken = false;
            //Creates a list of all Roles already in table
            List<Role> roleList = new List<Role>();
            roleList = rc.getAllRoles();
            int x = 0;
            Int32.TryParse(RoleCountBox.Text, out x);
            //Make sure Role isn't a negative number or 0
            if (x <= 0)
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                System.Windows.MessageBox.Show("Can't have a count of < 0. Please enter a valid count", "Error", button, icon);
            }
            //Make sure Role isn't greater than 999
            else if (x > 999)
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                System.Windows.MessageBox.Show("Can't have a count of > 999. Please enter a valid count", "Error", button, icon);
            }
            //Make sure the name or description fields are not blank
            else if (name.Text.Equals(""))
            {

                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                System.Windows.MessageBox.Show("The name field is empty. Please enter a name for the role", "Error", button, icon);
            }
            else if (description.Text.Equals(""))
            {

                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                System.Windows.MessageBox.Show("The description field is empty. Please enter a description", "Error", button, icon);
            }
            else
            {
                //Check to see if name or description is already in the role list
                foreach (Role u in roleList)
                {
                    if (name.Text.Equals(u.RoleName))
                    {
                        if (u.Id == passedID)
                        {
                            //It is the one being edited, so we are still good
                        }
                        else
                        {
                            MessageBoxButton button = MessageBoxButton.OK;
                            MessageBoxImage icon = MessageBoxImage.Error;
                            System.Windows.MessageBox.Show("This role has already been entered in the database", "Error", button, icon);
                            //Cant have the same role name
                            isTaken = true;
                        }
                    }
                    else if (description.Text.Equals(u.RoleDescription))
                    {
                        if (u.Id == passedID)
                        {
                            //It is the one being edited, so we are still good
                        }
                        else
                        {
                            MessageBoxButton button = MessageBoxButton.OK;
                            MessageBoxImage icon = MessageBoxImage.Error;
                            System.Windows.MessageBox.Show("This description has already been entered in the database", "Error", button, icon);
                            //Cant have the same role description
                            isTaken = true;
                        }
                    }
                }
                if (isTaken == true)
                {
                    //If it is already in the table, don't allow the user to add it a second time
                }
                else
                {
                    //Once we have made sure it isn't in the table, we can update the Role being edited
                    role.RoleName = name.Text;
                    role.RoleDescription = description.Text;
                    role.RoleCount = x;
                    rc.editRole(role);
                    MessageBox.Show("Edit Successful!", "Edit Successful");
                    this.Close();
                }
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Nothing goes here
        }

        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Nothing goes here
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Nothing goes here
        }

        private void RoleCountBox_TextChanged(object sender, EventArgs e)
        {
            //Check to make sure they entered a number into role count. No letters or symbols allowed!
            if (System.Text.RegularExpressions.Regex.IsMatch(RoleCountBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers greater than zero.");
                RoleCountBox.Text = RoleCountBox.Text.Remove(RoleCountBox.Text.Length - 1);
            }
        }
    }
}
