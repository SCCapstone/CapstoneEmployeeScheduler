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
    /// Interaction logic for EditRoleModal.xaml
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
            passedID = id;
            role = (Role)rc.getRoleById(passedID);
            name.Text = role.RoleName;
            description.Text = role.RoleDescription;
            RoleCountBox.Text = role.RoleCount.ToString();
            role.RoleDescription = description.Text;

        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            //need way to check for empty fields
            int x = 0;
            Int32.TryParse(RoleCountBox.Text, out x);
            if (x <= 0)
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                System.Windows.MessageBox.Show("Can't have a count of < 0. Please enter a valid count", "Error", button, icon);
            }
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
                role.RoleName = name.Text;
                role.RoleDescription = description.Text;

                role.RoleCount = x;
                rc.editRole(role);
                MessageBox.Show("Edit Successful!", "Edit Successful");
                this.Close();
            }
            /*role.RoleName = name.Text;
            role.RoleDescription = description.Text;
            int x = 0;
            Int32.TryParse(RoleCountBox.Text, out x);
            role.RoleCount = x;
             */
            
            //this.Close();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RoleCountBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(RoleCountBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers greater than zero.");
                RoleCountBox.Text = RoleCountBox.Text.Remove(RoleCountBox.Text.Length - 1);
            }
        }
    }
}
