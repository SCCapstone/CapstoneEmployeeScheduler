using CapstoneEmployeeScheduler.Controllers;
using CapstoneEmployeeScheduler.Models;
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

namespace CapstoneEmployeeScheduler.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// This file is responsible for logging into the application. It differentiates between the admin and non admin users and is the gateway to the rest of the application
    /// </summary>
    public partial class LoginWindow : Window
    {
    
        public LoginWindow()
        {
            InitializeComponent();
            txtUsername.Focus();
        }

        
        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            //Exits the application
            this.Close();
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Nothing goes here
        }

        private void txtUsername_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            //When they start typing, hide the word "Username" in the textbox
            if (txtUsername.Text.Length > 0)
                tbUsername.Visibility = Visibility.Collapsed;
            else
                tbUsername.Visibility = Visibility.Visible;
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //When they start typing, hide the word "Password" the textbox
            if (txtPassword.Password.Length > 0)
                tbPassword.Visibility = Visibility.Collapsed;
            else
                tbPassword.Visibility = Visibility.Visible;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            //When they click submit, try and login
            if (e.Key == Key.Enter)
            {
                buttonSubmit_Click(null, EventArgs.Empty);
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            //When they click submit, try and login
            if (e.Key == Key.Enter)
            {
                buttonSubmit_Click(null, EventArgs.Empty);
            }
        }

        public void buttonSubmit_Click(object sender, EventArgs e)
        {
            //Call the login(username, password) method and check if they are able to login
            string username;
            string password;
            username = txtUsername.Text;
            password = txtPassword.Password;
            login(username, password);

        }
        public void login(string username, string password)
        {
            //Method used for logging into the Capstone Employee Scheduler
            UserController uc = new UserController();
            List<User> users = uc.getAllUsersWithoutRoles();
            bool success = false;
            //If the user left either of the fields empty, tell them to fill them in
            if (txtUsername.Text == "" || txtPassword.Password == "")
            {
                MessageBox.Show("Please provide Username and Password");
                return;
            }

            if ((this.txtUsername.Text == "admin") && (this.txtPassword.Password == "admin"))
            {
                //If they use admin,admin, the application will launch and the ISADMIN field is set to true
                App.ISADMIN = true;
                MainWindow m = new MainWindow();
                m.Show();
                this.Close();
                success = true;
            }
            foreach(User u in users)
            {
                if (u.Email.Equals(txtUsername.Text) && txtPassword.Password.Equals("Password"))
                {
                    //If they set password as "Password", Prompt the user create a new password
                    if (u.Admin)
                        App.ISADMIN = true;
                    else
                        App.ISADMIN = false;
                    CreatePassword cp = new CreatePassword(u.Id);
                    cp.Show();
                    this.Close();
                    success = true;
                }
                else if (u.Email.Equals(txtUsername.Text) && txtPassword.Password.Equals(u.Password))
                {
                    //If they enter valid credentials, allow the user to enter the application
                    if (u.Admin)
                        App.ISADMIN = true;
                    else
                        App.ISADMIN = false;
                    MainWindow m = new MainWindow();
                    m.Show();
                    this.Close();
                    success = true;
                }
            }
            //If not, then do not let them into the application
            if(!success)
                MessageBox.Show("Incorrect Credentials");
        }
    }

}