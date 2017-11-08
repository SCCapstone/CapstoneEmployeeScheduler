﻿using System;
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
        static int attempt = 3;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            string username;
            string password;
            username = txtUsername.Text;
            password = txtPassword.Password;

            if (txtUsername.Text == "" || txtPassword.Password == "")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }

            if ((this.txtUsername.Text == "admin") && (this.txtPassword.Password == "admin"))
            {
                attempt = 0;
                MessageBox.Show("Success!");
                MainWindow m = new MainWindow();
                m.Show();
                this.Close();
            }

            else if ((attempt == 3) && (attempt > 0))
            {
                //nothing yet
                Label.Content = ("Incorrect credentials. You have " + Convert.ToString(attempt) + " attempts remaining.");
                --attempt;
            }


        }
    }
}
