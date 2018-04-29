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
using CapstoneEmployeeScheduler.Models;
using CapstoneEmployeeScheduler.Views;
namespace CapstoneEmployeeScheduler
{
    /// <summary>
    /// Interaction logic for FirstPassword.xaml
    /// </summary>
    public partial class FirstPassword : Window
    {
        //bool IsOld = App.ISOLD;
        public FirstPassword()
        {
           
                InitializeComponent();
            
            
        }

       

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Checks for matching passwords. If accepted, create a new user that is disabled for scheduling, so basically hidden. will be an admin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (Username.Text == "")
            {
                MessageBox.Show("Please enter a username");
            }
            else if (SetPass.Password == null)
            {
                MessageBox.Show("Please enter a password");
            }
            else if (SetPass.Password != ConfirmPass.Password)
            {
                MessageBox.Show("Passwords do not match!");
            }
            else
            {
                User u = new User();
                UserController uc = new UserController();
                u.UserName = Username.Text;
                u.Password = ConfirmPass.Password;
                u.Disabled = true;
                u.Admin = true;
                u.email = "";
                u.shift = "";
                
                //App.ISOLD = true;
                uc.createUser(u);
               
                MainWindow m = new MainWindow();
                m.Show();
                this.Close();

            }

        }
    }
}
