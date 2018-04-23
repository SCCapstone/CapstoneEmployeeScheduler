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
            RoleController rc = new RoleController();
            schedule.ItemsSource = CreateTable().DefaultView;
        }
       public DataTable CreateTable()
        {
            //Method for getting the schedule and displaying it in a datagrid
            DataTable dt = new DataTable();
            Schedule s = new Schedule();
            ScheduleController sc = new ScheduleController();
            UserController uc = new UserController();
            RoleController rc = new RoleController();
            //Get the schedule by the specific date
            s = sc.getScheduleByDate(DateTime.Today);

            //Create the columns for the schedule
            dt.Columns.Add("Employee", typeof(string));
            dt.Columns.Add("Shift", typeof(string));
            dt.Columns.Add("Role", typeof(string));

            //Iterate through the UserRoles table and get all the schedule data
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
            //Set the font size and text alignment of the title of the page and add it
            t.FontSize = 36;
            t.TextAlignment = TextAlignment.Center;
            fd.Blocks.Add(t);

            fd.ColumnWidth = printDlg.PrintableAreaWidth;
            fd.ColumnGap = 10.0;
            //Create the Columns for the printed report
            int padding = 45;
            string name = "Name";
            string shift = "Shift";
            string role = "Role";
            Paragraph l = new Paragraph(new Run(String.Format("{0}{1}{2}", name.PadRight(padding), shift.PadRight(padding), role)));
            l.FontSize = 24;
            l.TextAlignment = TextAlignment.Left;
            fd.Blocks.Add(l);
            int maxLength = 20;
            //Now add the data from the Listview
            Paragraph u = new Paragraph();
            foreach (DataRowView item in schedule.ItemsSource)
            {
                string employeeName = (string)item[0];
                shift = (string)item[1];
                role = (string)item[2];
                //If employee name is somehow empty, skip it
                if (employeeName.Length == 0)
                {
                    continue;

                }
                name = employeeName.Substring(0, employeeName.Length);
                if (employeeName.Length >= maxLength)
                {
                    //If the name is longer than the preset max length, cut it off at the max to line up columns
                    employeeName = employeeName.Substring(0, maxLength);
                    name = employeeName.PadRight(maxLength - employeeName.Length);

                }
                else
                {
                    //If under the max length, pad right with blank spaces until it reaches the max and add a tab for column lining u
                     name = employeeName.PadRight(maxLength - employeeName.Length);
                    name = name + "\t";
                }
                //fd.Blocks.Add(new Paragraph(new Run(item.userName)));
                u = new Paragraph(new Run(name + "\t\t\t" + shift + "\t\t\t" + role));
                u.TextAlignment = TextAlignment.Left;
                fd.Blocks.Add(u);
            }

            fd.Name = "Schedule";
            IDocumentPaginatorSource idpSource = fd;
            printDlg.ShowDialog();
            //Print the dialog to the specific location
            printDlg.PrintDocument(idpSource.DocumentPaginator, "Today's Schedule");
            System.Windows.MessageBox.Show("The Print completed!");
        }
    }
}
