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
using System.Windows.Forms;
using CapstoneEmployeeScheduler.Model;
using CapstoneEmployeeScheduler.Controllers;
using CapstoneEmployeeScheduler.Algorithm;
using System.Data;

namespace CapstoneEmployeeScheduler.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    /// 
     
    
    
    public partial class ShowSchedule : Page
    {
        

        public ShowSchedule()
        {
            InitializeComponent();
            //Schedule s = new Schedule();
            //ScheduleController sc = new ScheduleController();
            //UserController uc = new UserController();
            //List<User> users = new List<User>();
            //users = uc.getAllUsers();
            //makeSchedule a = new makeSchedule();
            //a.Generate(users);
            //s = sc.getScheduleByDate(DateTime.Today);
            //showTheSchedule.View = View.Details;
            //MyGridView.Columns.Add("Frequency");

            //showTheSchedule.Items.Add(new System.Windows.Forms.ListViewItem(new string[] { "employee" }));
            showTheSchedule.ItemsSource = CreateTable().DefaultView;
        }

        public DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            Schedule s = new Schedule();
            ScheduleController sc = new ScheduleController();
            UserController uc = new UserController();
            RoleController rc = new RoleController();
            s = sc.getScheduleByDate(DateTime.Today);

            dt.Columns.Add("Employee", typeof(string));
            dt.Columns.Add("Shift", typeof(string));
            dt.Columns.Add("Role", typeof(string));

            for (int i = 0; i < s.UserRoles.Count; i++)
            {
                User u = uc.getUserById(s.UserRoles.ElementAt(i).Key);
                Role r = rc.getRoleById(s.UserRoles.ElementAt(i).Value);
                dt.Rows.Add(u.UserName, u.Shift, r.RoleName);
            }
            return dt;

        }

        private void PrintSButton_Click(object sender, RoutedEventArgs e)
        {
            //method for printing table of employees
            //TODO: once schedule is able to be displayed, move to schedule
            System.Windows.Controls.PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
            if (printDlg.ShowDialog() == true)
            {
                printDlg.PrintVisual(showTheSchedule, "List of Employees");
            }
        }
    }
}
