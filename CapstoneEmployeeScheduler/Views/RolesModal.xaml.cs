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
    /// Interaction logic for RolesModal.xaml
    /// </summary>
    public partial class RolesModal : Window
    {
        public string des;
        public RolesModal()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            RoleController r = new RoleController();
            Role role = new Role();
            List<Role> roleList = new List<Role>();
            roleList = r.getAllRoles();
            Boolean isTaken = false;
            //need way to check for empty fields
            int x = 0;
            Int32.TryParse(RoleCountBox.Text, out x);
            if(x <= 0)
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                System.Windows.MessageBox.Show("Can't have a count of < 0. Please enter a valid count", "Error", button, icon);
            }
            else if (x > 999)
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                System.Windows.MessageBox.Show("Can't have a count of > 999. Please enter a valid count", "Error", button, icon);
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
                foreach (Role u in roleList)
                {
                    if (name.Text.Equals(u.RoleName))
                    {
                        MessageBoxButton button = MessageBoxButton.OK;
                        MessageBoxImage icon = MessageBoxImage.Error;
                        System.Windows.MessageBox.Show("This role has already been entered in the database", "Error", button, icon);
                        isTaken = true;
                    }
                    else if (description.Text.Equals(u.RoleDescription))
                    {
                        MessageBoxButton button = MessageBoxButton.OK;
                        MessageBoxImage icon = MessageBoxImage.Error;
                        System.Windows.MessageBox.Show("This description has already been entered in the database", "Error", button, icon);
                        isTaken = true;
                    }
                }
                if (isTaken == true)
                {
                    //dont add
                }
                else
                {
                    role.RoleName = name.Text;
                    role.RoleDescription = description.Text;

                    role.RoleCount = x;
                    r.createRole(role);
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
