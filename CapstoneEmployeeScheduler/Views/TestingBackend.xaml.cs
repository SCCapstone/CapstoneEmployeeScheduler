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
            //     private int id;
            //private string userName;
            //private string email;
            //private string shift;
            //private int roleOneDayAgo;
            //private int roleTwoDaysAgo;
            //private int roleThreeDaysAgo;
            //private bool outOfWork;
            //private bool disabled;
            //private bool admin;
            //private string password;

            UserController userController = new UserController();
            User user = new User();
            user.Id = 111;
            user.UserName = "Chance";
            user.Email = "@gmail";
            user.Shift = "Day";
            //user.RoleOneDayAgo;
            //user.RoleTwoDaysAgo = null;
            //user.RoleThreeDaysAgo = null;
            user.OutOfWork = false;
            user.Disabled = false;
            user.Admin = false;
            user.Password = "Password2";
            //userController.createUser(user);
            user = userController.getUserById(4006);
            //Console.WriteLine(user.Email);
            user.Email = "new";
            userController.editUser(user);
            //Console.WriteLine(user.Email);

            List<User> users = userController.getAllUsers();
            for(int i=0;i<users.Count;i++)
            {
                //Console.WriteLine(users.ElementAt(i).Id);
            }



            RoleController roleController = new RoleController();
            Role role = new Role();
            role.Id = 1;
            role.RoleName = "Change";
            //roleController.createRole(role);
            roleController.editRole(role);
        }
    }
}
