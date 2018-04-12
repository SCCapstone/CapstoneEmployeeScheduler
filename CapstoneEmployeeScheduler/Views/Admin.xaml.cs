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
    /// Interaction logic for admin.xaml
    /// </summary>
    public partial class admin : Page
    {
        public admin()
        {
            InitializeComponent();
            
        }

        private void update()
        {
            PermissionController pc = new PermissionController();
            Permission p = new Permission();
           
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
             pc.editPermissions(p);
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                update();
                MessageBox.Show("Permissions updated succesfully");
            }
            catch (System.Exception)
            {

            }          
        }

        
    }
}
