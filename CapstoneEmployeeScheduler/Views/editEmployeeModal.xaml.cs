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
using CapstoneEmployeeScheduler.Model;
using CapstoneEmployeeScheduler.Controllers;
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
            //displays role that are able to be selected
            List<Role> items = new List<Role>();
            RoleController r = new RoleController();
            items = r.getAllRoles();
            roleList.ItemsSource = items;
            items = r.getAllRoles();
            roleList.ItemsSource = items;
            

        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
           
            //Once the submit button is selected, updates database values
            user.userName = name.Text;
            user.email = email.Text;
            user.shift = "something";
            user.Password = " ";
            uc.editUser(user);
            //add roles the user selected
            List<Role> listItems = new List<Role>();
            foreach (Role role in roleList.SelectedItems)
            {
                listItems.Add(role);
            }
            user.Roles = listItems;
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
