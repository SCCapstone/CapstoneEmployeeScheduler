using CapstoneEmployeeScheduler.Controllers;
using CapstoneEmployeeScheduler.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for PastSchedule.xaml
    /// </summary>
    public partial class PastSchedule : Window
    {
        public PastSchedule()
        {
            InitializeComponent();
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
            showTheSchedule.ItemsSource = dt.DefaultView;

        }
    }
}
