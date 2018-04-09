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

        

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            PermissionController pc = new PermissionController();
            Permission p = new Permission();
            if (employee.IsChecked == true)
            {
                p.EmployeePage = true; 
            }
            if (roles.IsChecked == true)
            {
                p.RolePage = true;
            }
            if (history.IsChecked == true)
            {
                p.HistoryPage = true;
            }
            if (view.IsChecked == true)
            {
                p.TodaysSchedule = true;
            }
            if (generate.IsChecked == true)
            {
                p.GenerateSchedule = true;
            }
            MessageBox.Show("Permissions updated succesfully");
        }

        
    }
}
