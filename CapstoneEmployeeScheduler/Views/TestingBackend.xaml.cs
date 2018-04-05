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
using CapstoneEmployeeScheduler.DAO;
using CapstoneEmployeeScheduler.Models;
using CapstoneEmployeeScheduler.Controllers;

namespace CapstoneEmployeeScheduler.Views
{
    /// <summary>
    /// Interaction logic for TestingBackend.xaml
    /// </summary>
    public partial class TestingBackend : Page
    {
        public TestingBackend()
        {
            InitializeComponent();
        }

        public void UserDAO_Click(object sender, RoutedEventArgs e)
        {
            ScheduleController sc = new ScheduleController();
            Schedule s = new Schedule();
            s.ScheduleDate = DateTime.Today;
            s.UserRoles.Add(123, 123);
            s.UserRoles.Add(1234, 123);
            sc.createSchedule(s);
            s = sc.getScheduleByDate(DateTime.Today);
            Console.WriteLine(s.Id);
            
        }

        public string TestGet()
        {
            RoleController rc = new RoleController();
            List<Role> roles = rc.getAllRoles();
            for(int i=0;i<roles.Count;i++)
            {
                if(roles.ElementAt(i).RoleName.Equals("Testing Role"))
                {
                    return "Testing Role";
                }
            }
            return "Failure";
        }
    }
}
