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
            this.Close();
            MessageBox.Show("Application Exited Succesfully");
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtUsername_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (txtUsername.Text.Length > 0)
                tbUsername.Visibility = Visibility.Collapsed;
            else
                tbUsername.Visibility = Visibility.Visible;
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password.Length > 0)
                tbPassword.Visibility = Visibility.Collapsed;
            else
                tbPassword.Visibility = Visibility.Visible;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                buttonSubmit_Click(null, EventArgs.Empty);
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                buttonSubmit_Click(null, EventArgs.Empty);
            }
        }

        public void buttonSubmit_Click(object sender, EventArgs e)
        {
            string username;
            string password;
            username = txtUsername.Text;
            password = txtPassword.Password;
            login(username, password);

        }
        public void login(string username, string password)
        {
            UserController uc = new UserController();
            List<User> users = uc.getAllUsersWithoutRoles();
            bool success = false;
            if (txtUsername.Text == "" || txtPassword.Password == "")
            {
                MessageBox.Show("Please provide Username and Password");

                return;
            }

            if ((this.txtUsername.Text == "admin") && (this.txtPassword.Password == "admin"))
            {

                //MessageBox.Show("Login Successful!", "Success!");
                MainWindow m = new MainWindow();
                m.Show();
                this.Close();
                success = true;
            }
            foreach(User u in users)
            {
                if (u.Email.Equals(txtUsername.Text) && txtPassword.Password.Equals("Password"))
                {
                    //MainWindow m = new MainWindow();
                    //m.Show();
                    CreatePassword cp = new CreatePassword(u.Id);
                    cp.Show();
                    this.Close();
                    success = true;
                }
                else if (u.Email.Equals(txtUsername.Text) && txtPassword.Password.Equals(u.Password))
                {
                    MainWindow m = new MainWindow();
                    m.Show();
                    this.Close();
                    success = true;
                }
            }
            if(!success)
                MessageBox.Show("Incorrect Credentials");
        }
    }

}