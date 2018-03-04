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
using CapstoneEmployeeScheduler.Model;
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
            /*
            Schedule s = new Schedule();
            UserController uc = new UserController();
            List<User> users = new List<User>();
            users = uc.getAllUsers();
            makeSchedule a = new makeSchedule();
            a.Generate(users);
            */
            ShowSchedule schedule = new ShowSchedule();
            schedule.Show();
        }
    }
}
