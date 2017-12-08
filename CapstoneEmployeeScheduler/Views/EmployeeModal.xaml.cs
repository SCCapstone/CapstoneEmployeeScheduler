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
using CapstoneEmployeeScheduler.Controllers;
using CapstoneEmployeeScheduler.DAO;
using CapstoneEmployeeScheduler.Model;

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
            RoleController r = new RoleController();
            List<Role> items = new List<Role>();
            items = r.getAllRoles();
            roleList.ItemsSource = items;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            UserController uc = new UserController();
            User user = new User();
            user.UserName = name.Text;
            user.Email = email.Text;
           
            user.Shift = " ";
            user.OutOfWork = false;
            user.Disabled = false;
            user.Admin = false;
            user.Password = " ";
            //user.Roles = roles.SelectedItems;
            uc.createUser(user);

            /*RoleController rc = new RoleController();
            Role role = new Role();
            //int roleId = role.Id;
            int userId = user.Id;
            
            this.Close();*/
        }

        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
