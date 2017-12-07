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
using CapstoneEmployeeScheduler.Model;
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

        private void UserDAO_Click(object sender, RoutedEventArgs e)
        {
            UserController userController = new UserController();
            //User user = userController.getUserById(4007);
            //user.shift = "newShift";
            //user.email = "newEmail";
            //user.UserName = "newName";
            //user.Password = "newPassword";
            //user.OutOfWork = false;
            //user.Disabled = false;
            //user.Admin = false;
            //Role role1 = new Role();
            //Role role2 = new Role();
            //role1.Id = 3;
            //role2.Id = 4;
            //List<Role> roles = new List<Role>();
            //roles.Add(role1);
            //roles.Add(role2);
            //user.Roles = roles;
            //userController.editUser(user);




            //User user2 = userController.getUserById(4007);
            //List<Role> roles2 = user2.Roles;
            //foreach(Role role in roles2)
            //{
            //    Console.WriteLine(role.Id);
            //    Console.WriteLine(role.RoleName);
            //}
            List<User> users = userController.getAllUsers();
            foreach(User user in users)
            {
                Console.WriteLine("User: " + user.Id);
                foreach(Role role in user.Roles)
                {
                    Console.WriteLine("Role: " + role.Id);
                    Console.WriteLine(role.RoleName);
                }
            }
        }
    }
}
