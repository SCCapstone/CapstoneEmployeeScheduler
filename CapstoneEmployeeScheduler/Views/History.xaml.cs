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
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : Page
    {
        public History()
        {
            ShowTable();
        }

        private void ShowTable()
        {
            //Method to show past schedules
            DataTable dt = new DataTable();
            List<Schedule> items = new List<Schedule>();
            ScheduleController sc = new ScheduleController();
            InitializeComponent();
            dt.Columns.Add("Date", typeof(DateTime));
            Schedule s = sc.getScheduleByDate(DateTime.Today.AddDays(6));
            if (s.Id != null)
            {
                dt.Rows.Add(DateTime.Today.AddDays(6));
            }
            s = sc.getScheduleByDate(DateTime.Today.AddDays(5));
            if (s.Id != null)
            {
                dt.Rows.Add(DateTime.Today.AddDays(5));
            }
            s = sc.getScheduleByDate(DateTime.Today.AddDays(4));
            if (s.Id != null)
            {
                dt.Rows.Add(DateTime.Today.AddDays(4));
            }
            s = sc.getScheduleByDate(DateTime.Today.AddDays(3));
            if (s.Id != null)
            {
                dt.Rows.Add(DateTime.Today.AddDays(3));
            }
            s = sc.getScheduleByDate(DateTime.Today.AddDays(2));
            if (s.Id != null)
            {
                dt.Rows.Add(DateTime.Today.AddDays(2));
            }
            s = sc.getScheduleByDate(DateTime.Today.AddDays(1));
            if (s.Id != null)
            {
                dt.Rows.Add(DateTime.Today.AddDays(1));
            }
            s = sc.getScheduleByDate(DateTime.Today);
            if (s.Id != null)
            {
                dt.Rows.Add(DateTime.Today);
            }
            s = sc.getScheduleByDate(DateTime.Today.AddDays(-1));
            if (s.Id != null)
            {
                dt.Rows.Add(DateTime.Today.AddDays(-1));
            }
            s = sc.getScheduleByDate(DateTime.Today.AddDays(-2));
            if (s.Id != null)
            {
                dt.Rows.Add(DateTime.Today.AddDays(-2));
            }
            s = sc.getScheduleByDate(DateTime.Today.AddDays(-3));
            if (s.Id != null)
            {
                dt.Rows.Add(DateTime.Today.AddDays(-3));
            }
            s = sc.getScheduleByDate(DateTime.Today.AddDays(-4));
            if (s.Id != null)
            {
                dt.Rows.Add(DateTime.Today.AddDays(-4));
            }
            s = sc.getScheduleByDate(DateTime.Today.AddDays(-5));
            if (s.Id != null)
            {
                dt.Rows.Add(DateTime.Today.AddDays(-5));
            }
            s = sc.getScheduleByDate(DateTime.Today.AddDays(-6));
            if (s.Id != null)
            {
                dt.Rows.Add(DateTime.Today.AddDays(-6));
            }

            GeneratedSchedules.SelectedIndex = 0;
            GeneratedSchedules.ItemsSource = dt.DefaultView;
        }

        private void view_Click(object sender, RoutedEventArgs e)
        {
            //Method to display schedule when picked in the table
            DataRowView drv = GeneratedSchedules.Items.GetItemAt(GeneratedSchedules.SelectedIndex) as DataRowView;
            DateTime date = Convert.ToDateTime(drv["Date"]);
            ScheduleController sc = new ScheduleController();
            //Get the correct date of the schedule to be deleted
            Schedule s = sc.getScheduleByDate(date);
            //If there is no schedule on that date, throw an error
            if (s == null)
            {
                System.Windows.MessageBox.Show("No Schedule Generated", "Error");
            }
           ShowSchedule ss = new Views.ShowSchedule(date);
            ss.Show();

        }

        private void History_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Nothing goes here
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Nothing goes here
        }

        private void deleteSchedule_Click(object sender, RoutedEventArgs e)
        {
            //deletes schedule when selected
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Are you sure you want to delete this schedule? This action cannot be undone!", "WARNING", MessageBoxButtons.YesNo);
            DataRowView drv = GeneratedSchedules.Items.GetItemAt(GeneratedSchedules.SelectedIndex) as DataRowView;
            DateTime date = Convert.ToDateTime(drv["Date"]);
            ScheduleController sc = new ScheduleController();
            //Get the correct date of the schedule to be deleted
            Schedule s = sc.getScheduleByDate(date);
            string id = s.Id;
            //Call delete schedule method to remove it
            sc.deleteSchedule(id);
            MessageBoxButton button = MessageBoxButton.OK;
            System.Windows.MessageBox.Show("Schedule deleted successfully.", "Schedule Deleted", button);
            //Once it is deleted, refresh the table so it doesn't appear in the table despite being deleted.
            ShowTable();

        }
    }
}
