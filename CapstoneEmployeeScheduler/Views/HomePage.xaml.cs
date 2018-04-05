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
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapstoneEmployeeScheduler.Models;
using CapstoneEmployeeScheduler.Controllers;
using CapstoneEmployeeScheduler.Algorithm;

namespace CapstoneEmployeeScheduler.Views
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            
            
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            ScheduleController sc = new ScheduleController();
            if (sc.getScheduleByDate(DateTime.Today).Id != null)
            {
                System.Windows.MessageBox.Show("There was already a schedule made today.");
            }
           
            Schedule s = new Schedule();
            MakeSchedule ms = new MakeSchedule();
            List<User> users = new List<User>();
            UserController uc = new UserController();
            users = uc.getAllUsersWithRoleId();
            ms.Generate(users);
            Content = new Views.ShowSchedule();
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            Content = new Views.ShowSchedule();
        }
    }
}
