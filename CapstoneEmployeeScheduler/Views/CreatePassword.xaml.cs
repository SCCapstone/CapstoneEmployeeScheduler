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
using CapstoneEmployeeScheduler.Models;
using CapstoneEmployeeScheduler.Views;
using CapstoneEmployeeScheduler.Controllers;

namespace CapstoneEmployeeScheduler.Views
{
    /// <summary>
    /// Interaction logic for CreatePassword.xaml
    /// </summary>
    public partial class CreatePassword : Window
    {
        private int passedID;
        UserController uc = new UserController();
        User u;
        public CreatePassword(int id)
        {
            InitializeComponent();
            passedID = id;
            u = uc.getUserById(passedID);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NewPass.Password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters in length");
            }
            else if (NewPass.Password != ConfirmPass.Password)
            {
                MessageBox.Show("Passwords do not match!");
            }
            else if (NewPass.Password == "")
            {
                MessageBox.Show("Please enter a password");
            }
            else if (ConfirmPass.Password == "")
            {
                MessageBox.Show("Please confirm your password");
            }
            else
            {
                string pwd;
                pwd = ConfirmPass.Password;
                u.Password = pwd;
                uc.editUser(u);
                MainWindow m = new MainWindow();
                m.Show();
                this.Close();
            }
           
        }


      
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
