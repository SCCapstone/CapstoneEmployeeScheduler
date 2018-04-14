using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CapstoneEmployeeScheduler.Controllers;
using CapstoneEmployeeScheduler.DAO;
using CapstoneEmployeeScheduler.Models;

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
            RoleController rc = new RoleController();
            List<Role> items = new List<Role>();
            items = rc.getAllRoles();
            roleList.Items.Clear();
            //populating the datagrid with roles
            var bindingList = new BindingList<Role>();
            foreach (Role role in items)
            {
                bindingList.Add(role);
            }
            var source = new BindingSource(bindingList, null);
            roleList.ItemsSource = source;
            roleList.IsReadOnly = false;
            //attempt to hide column names. Unsuccessful
            /*foreach (DataGridColumn col in roleList.Columns)
            {
                if (col.Header.Equals("Id"))
                {
                    col.Visibility = Visibility.Hidden;
                }
                if (col.Header.Equals("RoleDescription"))
                {
                    col.Visibility = Visibility.Hidden;
                }
                if (col.Header.Equals("RoleCount"))
                {
                    col.Visibility = Visibility.Hidden;
                }

            }
            //roleList.ItemsSource = items;
            */
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            UserController uc = new UserController();
            User user = new User();
            //RoleController rc = new RoleController();
            
            user.UserName = name.Text;
            user.Email = email.Text;
           
            user.Shift = ShiftBox.Text;
            if (isOutofWork.IsChecked.Value)
            {
                //if checkbox for disabled is true, set field
                user.OutOfWork = true;
            }
            else
            {
                user.OutOfWork = false;
            }
            if (isDisabled.IsChecked.Value)
            {
                //if checkbox for disabled is true, set field
                user.Disabled = true;
            }
            else
            {
                user.Disabled = false;
            }
            if (isAdmin.IsChecked.Value)
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
            if(listItems.Count == 0)
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Stop;
                System.Windows.MessageBox.Show("Employee Must be assigned at least one role!", "Capstone Employee Scheduler", button, icon);
                return;
            }
            user.Roles = listItems;
            

            uc.createUser(user);

            /*RoleController rc = new RoleController();
            Role role = new Role();
            //int roleId = role.Id;
            int userId = user.Id;
            */
            this.Close();
        }

        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void roleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
