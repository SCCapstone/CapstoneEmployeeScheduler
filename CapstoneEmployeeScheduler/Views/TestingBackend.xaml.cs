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
using CapstoneEmployeeScheduler.DAO;
using CapstoneEmployeeScheduler.Models;
using CapstoneEmployeeScheduler.Controllers;

namespace CapstoneEmployeeScheduler.Views
{
    /// <summary>
    /// Interaction logic for TestingBackend.xaml
    /// </summary>
    public partial class TestingBackend : Page
    {
        public TestingBackend()
        {
            InitializeComponent();
        }

        //This method is used for testing all of the backend methods
        //To use, uncomment out the button from TestingBackend.xaml and
        //add the method you want to test to this method then
        //run the app and click the testing button
        //This is mainly used by Chance when the front end for the method he wants
        //to test has not been created yet
        public void UserDAO_Click(object sender, RoutedEventArgs e)
        {
            //Test code in here
        }

        //Tests Creating, Getting, and Deleting a Role
        public string TestCreateGetDelete()
        {
            RoleController rc = new RoleController();
            Role role = new Models.Role();
            role.RoleName = "Testing Role";
            role.RoleCount = 7;
            role.RoleDescription = "Role for testing purposes";
            try
            {
                role = rc.createRole(role);
            }
            catch (System.Data.SqlClient.SqlException)
            {

            }
            try
            {
                int test = role.Id;
            }
            catch (NullReferenceException)
            {
                return "Create Role Failed";
            }
            Role getRole = rc.getRoleById(role.Id);
            if (!(getRole.Id >= 0))
            {
                return "Get Role Failed";
            }
            try
            {
                rc.deleteRole(role.Id);
            }
            catch (System.Data.SqlClient.SqlException)
            {

            }
            catch (NullReferenceException)
            {

            }
            if (!(rc.getRoleById(role.Id).Id >= 0))
            {
                return "Delete Role Failed";
            }
            return "Success";
        }
    }
}
