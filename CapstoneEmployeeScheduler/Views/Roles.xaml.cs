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
using CapstoneEmployeeScheduler.Controllers;
using CapstoneEmployeeScheduler.Models;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace CapstoneEmployeeScheduler.Views
{
    /// <summary>
    /// Interaction logic for Roles.xaml
    /// </summary>
    public partial class Roles : Page
    {
              
        public Roles()
        {
            InitializeComponent();
            RoleController r = new RoleController();
            List<Role> item = new List<Role>();
            item = r.getAllRoles();
            role.ItemsSource = item;
            
        }

        public void ShowTable()
        {
            //Method to show the table of roles since every method uses it
            RoleController r = new RoleController();
            List<Role> item = new List<Role>();
            item = r.getAllRoles();
            role.ItemsSource = item;
        }

        private void NewRole_Click(object sender, RoutedEventArgs e)
        {
            //Open the popup for creating a role 
            RolesModal m = new Views.RolesModal();
            m.ShowDialog();
            InitializeComponent();
            ShowTable();
           
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //Method to delete role from the database
            RoleController rc = new RoleController();
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Are you sure you want to delete Role(s)? This can not be undone!", "WARNING", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (Role roles  in role.SelectedItems)
                {
                    //If Multiple users are selected, delete them all
                    int roleID = roles.Id;
                    rc.deleteRole(roleID);
                }
                System.Windows.MessageBox.Show("Role(s) has been deleted.");
                ShowTable();
                //Rehide the buttons so it doesnt crash the program
                DeleteButton.Visibility = Visibility.Hidden;
                EditButton.Visibility = Visibility.Hidden;
            }
            else if (dialogResult == DialogResult.No)
            {
                //If they select no, nothing happens
                //Rehide the buttons so it doesnt crash the program
                DeleteButton.Visibility = Visibility.Hidden;
                EditButton.Visibility = Visibility.Hidden;
            }

        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            //This method is called when the edit button is pressed on one of the employees
            if (role.SelectedItems.Count >= 1)
            {
                foreach (Role roles in role.SelectedItems)
                {

                    //Gets the id of the role being edited and sends it to the modal
                    int id = roles.Id;
                    EditRoleModal rm = new Views.EditRoleModal(id);
                    rm.ShowDialog();
                }
                ShowTable();
                //Rehide the buttons so it doesnt crash the program
                DeleteButton.Visibility = Visibility.Hidden;
                EditButton.Visibility = Visibility.Hidden;
            }
        }

        private void role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (role.SelectedIndex >= 0)
            {
                //If they select something in the table, make the edit and delete buttons appear
                DeleteButton.Visibility = Visibility.Visible;
                DeleteButton.IsEnabled = true;
                EditButton.Visibility = Visibility.Visible;
                EditButton.IsEnabled = true;

            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Nothing goes here
        }

    }
}
