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
using CapstoneEmployeeScheduler.Models;
using CapstoneEmployeeScheduler.Controllers;
using CapstoneEmployeeScheduler.Algorithm;
using System.Data;

namespace CapstoneEmployeeScheduler.Views
{
    /// <summary>
    /// Interaction logic for ScheduleWindow.xaml
    /// </summary>
    public partial class ScheduleWindow : Window
    {
        public ScheduleWindow()
        {
            InitializeComponent();
            schedule.ItemsSource = CreateTable().DefaultView;
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
            //Print method for the schedule
            System.Windows.Controls.PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
            FlowDocument fd = new FlowDocument();
            //Title of Page
            Paragraph t = new Paragraph(new Run("Today's Schedule"));
            t.FontSize = 36;
            t.TextAlignment = TextAlignment.Center;
            fd.Blocks.Add(t);

            fd.ColumnWidth = printDlg.PrintableAreaWidth;
            fd.ColumnGap = 10.0;

            int padding = 40;
            string name = "Name";
            string shift = "Shift";
            Paragraph l = new Paragraph(new Run(String.Format("{0}{1}{2}", name.PadRight(padding), shift.PadRight(padding), "Role")));
            l.FontSize = 24;
            l.TextAlignment = TextAlignment.Left;
            fd.Blocks.Add(l);
            //Now add the data from the Listview
            Paragraph u = new Paragraph();
            foreach (User item in schedule.Items)
            {
                //fd.Blocks.Add(new Paragraph(new Run(item.userName)));
                u = new Paragraph(new Run(item.userName + "\t\t" + item.shift + "\t\t" + item.Roles));
                u.TextAlignment = TextAlignment.Left;
                fd.Blocks.Add(u);
            }

            fd.Name = "Schedule";
            IDocumentPaginatorSource idpSource = fd;
            printDlg.ShowDialog();
            printDlg.PrintDocument(idpSource.DocumentPaginator, "Today's Schedule");
            System.Windows.MessageBox.Show("The Print method completed!");
        }
    }
}
