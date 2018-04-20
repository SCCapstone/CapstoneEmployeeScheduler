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
        public string CreateGetDeleteRole()
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

        public string EditRole()
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
            getRole.RoleName = "Edit Name of Role!";
            try
            {
                rc.editRole(getRole);
            }
            catch
            {

            }
            Role getRole2 = rc.getRoleById(getRole.Id);
            if (!(getRole2.Id >= 0))
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




        public string CreateGetDeleteUser()
        {
            User user = new Models.User();
            UserController uc = new UserController();
            user.UserName = "Testing User";
            user.Email = "Test user email";
            user.Shift = "Day Shift";
            try
            {
                user = uc.createUser(user);
            }
            catch (System.Data.SqlClient.SqlException)
            {

            }
            catch (NullReferenceException)
            {

            }
            try
            {
                int test = user.Id;
            }
            catch (NullReferenceException)
            {
                return "Create User Failed";
            }
            User getUser = null;
            try
            {
                getUser = uc.getUserById(user.Id);
            }
            catch (NullReferenceException)
            {

            }
            try
            {
                uc.deleteUserById(user.Id);
            }
            catch (System.Data.SqlClient.SqlException)
            {

            }
            catch (NullReferenceException)
            {

            }
            try
            {
                if (!(uc.getUserById(user.Id).Id >= 0))
                {
                    return "Delete User Failed";
                }
            }
            catch (NullReferenceException)
            {

            }
            return "Success";
        }

        public string EditUser()
        {
            User user = new Models.User();
            UserController uc = new UserController();
            user.UserName = "Testing User";
            user.Email = "Test user email";
            user.Shift = "Day Shift";
            try
            {
                user = uc.createUser(user);
            }
            catch (System.Data.SqlClient.SqlException)
            {

            }
            catch (NullReferenceException)
            {

            }
            try
            {
                int test = user.Id;
            }
            catch (NullReferenceException)
            {
                return "Create User Failed";
            }
            User editUser = new Models.User();
            editUser.UserName = "Edit User Name";
            try
            {
                uc.editUser(editUser);
            }
            catch
            {

            }
            if (!editUser.UserName.Equals("Edit User Name"))
            {
                return "Edit User Failed";
            }
            try
            {
                uc.deleteUserById(user.Id);
            }
            catch (System.Data.SqlClient.SqlException)
            {

            }
            catch (NullReferenceException)
            {

            }
            try
            {
                if (!(uc.getUserById(user.Id).Id >= 0))
                {
                    return "Delete User Failed";
                }
            }
            catch (NullReferenceException)
            {

            }
            return "Success";
        }
    }
}
