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
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : Page
    {
        public History()
        {
            DataTable dt = new DataTable();
            List<Schedule> items = new List<Schedule>();
            ScheduleController sc = new ScheduleController();
            InitializeComponent();
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Rows.Add(DateTime.Today);
            dt.Rows.Add(DateTime.Today.AddDays(-1));
            dt.Rows.Add(DateTime.Today.AddDays(-2));
            dt.Rows.Add(DateTime.Today.AddDays(-3));
            dt.Rows.Add(DateTime.Today.AddDays(-4));
            dt.Rows.Add(DateTime.Today.AddDays(-5));

            GeneratedSchedules.ItemsSource = dt.DefaultView;
            
        }

        private void view_Click(object sender, RoutedEventArgs e)
        {
            //DateTime date = (DateTime)GeneratedSchedules.SelectedItem;
            ScheduleController sc = new ScheduleController();
            Schedule s = sc.getScheduleByDate(DateTime.Today);//date);
            if (s == null)
            {
                System.Windows.MessageBox.Show("No Schedule Generated Yesterday", "Error");
            }
            PastSchedule p = new Views.PastSchedule();
            p.ShowDialog();

        }

        private void History_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
