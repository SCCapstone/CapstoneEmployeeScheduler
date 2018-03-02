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
using System.Windows.Forms;
using CapstoneEmployeeScheduler.Model;
using CapstoneEmployeeScheduler.Controllers;

namespace CapstoneEmployeeScheduler.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    /// 
     
    
    
    public partial class ShowSchedule : Window
    {

        DataGridView dt = new DataGridView();
        int numberofEmployees = CapstoneEmployeeScheduler.Algorithm.makeSchedule.userCount;

        public ShowSchedule()
        {
            //InitializeComponent();
            List<User> users = new List<User>();
            UserController u = new UserController();
            users = u.getAllUsers();
            showTheSchedule.ItemsSource = users;

            
        }

    }
}
