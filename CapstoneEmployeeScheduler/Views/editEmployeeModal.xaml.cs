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

            //roleList.SelectedItems.Add(role);
            foreach (Role rol in roleList.Items)
            {
                if (user.Roles.Contains(rol))
                {
                    roleList.SelectedItems.Add(rol);
                }
            }
            
            for (int index = 0; index < roleList.Items.Count; index++)
            {
                Role rol = (Role)roleList.Items[index];
                for (int k = 0; k < user.Roles.Count; k++)
                {
                    if (rol == user.Roles[k])
                    {
                        DataRowView row = (DataRowView)roleList.Items[index];
                        roleList.SelectedItems.Add(row);
                    }
                }
            }
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
           
            //Once the submit button is selected, updates database values
            user.userName = name.Text;
            user.email = email.Text;
            user.shift = ShiftBox.Text;
            user.Password = " ";
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
            if (isOutofWork.IsChecked == true)
            {
                //if checkbox for disabled is true, set field
                user.OutOfWork = true;
            }
            else
            {
                user.OutOfWork = false;
            }
            //add roles the user selected
            List<Role> listItems = new List<Role>();
            foreach (Role role in roleList.SelectedItems)
            {
                MessageBox.Show("Role: " + role.RoleName);
                if (user.Roles.Contains(role))
                {
                    MessageBox.Show("Already assigned role");
                }
                else
                {
                    MessageBox.Show("Added role: " + role.RoleName);
                    listItems.Add(role);
                }
            }
            user.Roles = listItems;
            uc.editUser(user);
            MessageBox.Show("Edit Successful!", "Edit Successful");
            this.Close();
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
