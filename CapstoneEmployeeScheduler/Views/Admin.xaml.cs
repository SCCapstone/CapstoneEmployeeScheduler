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
using CapstoneEmployeeScheduler.Controllers;
using CapstoneEmployeeScheduler.DAO;
using CapstoneEmployeeScheduler.Models;

namespace CapstoneEmployeeScheduler.Views
{
    /// <summary>
    ///Admin checks a list of permissions stored in the SQL database. Each value in the checkboxes edits the permissons. After editing,
    ///A non-admin user will only be able to access the pages they are allowed to. They will be prompted that they are unable to access the page
    /// </summary>
    public partial class admin : Page
    {
        public admin()
        {
            InitializeComponent();
            //Set the checkbox values to the current permission values
            List <bool> perms = checkPerms();
            employee.IsChecked = perms[0];
            roles.IsChecked = perms[1];
            history.IsChecked = perms[2];
            view.IsChecked = perms[3];
            generate.IsChecked = perms[4];
            
        }

        private List<bool> checkPerms()
        {
            List<bool> perms = new List<bool>();
            PermissionController pc = new PermissionController();
            Permission p = pc.getPermissions();
            //Add to list in order to keep checkboxes checked/unchecked
            perms.Add(p.EmployeePage);
            perms.Add(p.RolePage);
            perms.Add(p.HistoryPage);
            perms.Add(p.TodaysSchedule);
            perms.Add(p.GenerateSchedule);

            return perms;
        }
        private void update()
        {
            PermissionController pc = new PermissionController();
            Permission p = new Permission();
            List<bool> perms = new List<bool>();
            //check all the checkboxes and update database tables accordingly
            if (employee.IsChecked == true)
             {
                   p.EmployeePage = true; 
             }
            else
            {
                   p.EmployeePage = false;
            }
            if (roles.IsChecked == true)
            {
                   p.RolePage = true;
            }
            else
            {
               p.RolePage = false;
            }
            if (history.IsChecked == true)
            {
                p.HistoryPage = true;
            }
            else
            {
                p.HistoryPage = false;
            }
            if (view.IsChecked == true)
            {
                 p.TodaysSchedule = true;
            }
            else
            {
                p.TodaysSchedule = false;
            }
            if (generate.IsChecked == true)
            {
               p.GenerateSchedule = true;
            }
            else
            {
               p.GenerateSchedule = false;
            }
            //Call the permission controller to edit the permissions to update the database values
            pc.editPermissions(p);
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            //Method when clicking the submit method after changing the values of the permission in the Update method
            try
            {
                update();
                MessageBox.Show("Permissions updated succesfully");
            }
            catch (System.Exception)
            {
                //Catch an exception if they are not updated successfully
            }          
        }

        private void BoxChanged(object sender, RoutedEventArgs e)
        {
            //Nothing goes here
        }
    }
}
