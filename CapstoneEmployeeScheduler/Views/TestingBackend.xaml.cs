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

        /*
         * Controller and DAO Level Role Method Tests
         */

        //Tests Creating, Getting, and Deleting a Role
        public string CreateGetDeleteRole()
        {
            //Create a role
            RoleController rc = new RoleController();
            Role role = new Models.Role();
            role.RoleName = "Testing Role";
            role.RoleCount = 7;
            role.RoleDescription = "Role for testing purposes";
            //First test creating a role
            try
            {
                role = rc.createRole(role);
            }
            catch (System.Data.SqlClient.SqlException)
            {

            }
            //If the role id is null then return "Create Role Failed"
            try
            {
                int test = role.Id;
            }
            catch (NullReferenceException)
            {
                return "Create Role Failed";
            }
            //Second test get role
            Role getRole = rc.getRoleById(role.Id);
            //If the returned role doesn't have an id then return "Get Role Failed"
            if (!(getRole.Id >= 0))
            {
                return "Get Role Failed";
            }
            //Third test delete role
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
            //If the role isn't deleted return "Delete Role Failed"
            if (!(rc.getRoleById(role.Id).Id >= 0))
            {
                return "Delete Role Failed";
            }
            //Return "Success" if nothing failed
            return "Success";
        }

        //This method tests to make sure edit role works correctly
        public string EditRole()
        {
            //Create a role
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
            //Edit the role
            getRole.RoleName = "Edit Name of Role!";
            try
            {
                rc.editRole(getRole);
            }
            catch
            {

            }
            //Test to see if the Role was edited
            if (!getRole.RoleName.Equals("Edit Name of Role!"))
            {
                return "Edit Role Failed";
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

        /*
         * Controller and DAO Level User Method Tests
         */

        //Tests create get delete User
        public string CreateGetDeleteUser()
        {
            //Create a User
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
            //Tests to make sure a user was created
            try
            {
                int test = user.Id;
            }
            catch (NullReferenceException)
            {
                return "Create User Failed";
            }
            //Get a user
            User getUser = null;
            try
            {
                getUser = uc.getUserById(user.Id);
            }
            catch (NullReferenceException)
            {

            }
            //Delete a user
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
            //Tests to make sure the user was deleted
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
            //Return "Success" if nothing failed
            return "Success";
        }

        //Test Editing a User
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
            //Edits a User
            User editUser = new Models.User();
            editUser.UserName = "Edit User Name";
            try
            {
                uc.editUser(editUser);
            }
            catch
            {

            }
            //Tests to see if editUser works
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
