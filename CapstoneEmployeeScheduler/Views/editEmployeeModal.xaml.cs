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
            
            InitializeComponent();
            passedID = id;
            //UserController uc = new UserController();
            //User user = uc.getUserById(passedID);
            user = uc.getUserById(passedID);
            name.Text = user.userName;
            email.Text = user.email;
            //user.shift = "something";
            //user.Password = " ";
            //uc.editUser(user);
            //MessageBox.Show("Edit Successful!", "Edit Successful");
            //this.Close();
            //List<Role> items = new List<Role>();
            //items = r.getAllRoles();
            // roleList.ItemsSource = items;
            

        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            
            //TODO: When creating table in Employee.xaml, display id as well
            //Then get ID of current user and should work.
            //UserController uc = new UserController();
            //int currentID =  passedID;  //WHAT GOES HERE
            //User user = uc.getUserById(passedID);
            user.userName = name.Text;
            user.email = email.Text;
            user.shift = "something";
            user.Password = " ";
            uc.editUser(user);
            MessageBox.Show("Edit Successful!", "Edit Successful");
            this.Close();
        }

        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
