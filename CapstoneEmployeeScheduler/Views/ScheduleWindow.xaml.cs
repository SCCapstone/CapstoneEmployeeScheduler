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
using System.Windows.Navigation;
using CapstoneEmployeeScheduler.Models;
using CapstoneEmployeeScheduler.Controllers;
using CapstoneEmployeeScheduler.Algorithm;
using CapstoneEmployeeScheduler.Views;
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
            List<Role> roles = rc.getAllRoles();
            List<User> users = uc.getAllUsersWithoutRoles();
            //Iterate through the UserRoles table and get all the schedule data
            for (int i = 0; i < s.UserRoles.Count; i++)
            {
                User u = (User)users.Where(uu => uu.Id == s.UserRoles.ElementAt(i).Key).ElementAt(0);
                Role r = (Role)roles.Where(rr => rr.Id == s.UserRoles.ElementAt(i).Value).ElementAt(0);
                dt.Rows.Add(u.UserName, u.Shift, r.RoleName);
            }
            return dt;

        }


        private void PrintSButton_Click(object sender, RoutedEventArgs e)
        {
            int currentRow = 2;//Print method for the schedule
            System.Windows.Controls.PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
            Nullable<bool> result = printDlg.ShowDialog();
            //Process print file dialog box results
            if (result == true)
            {
                FlowDocument fd = new FlowDocument();
                //Create a table to store all the values from datagrid
                Table table = new Table();
                fd.Blocks.Add(table);

                //Title of Page
                Paragraph t = new Paragraph(new Run("Today's Schedule"));
                //Set the font size and text alignment of the title of the page and add it
                t.FontSize = 36;
                t.TextAlignment = TextAlignment.Center;

                //Create the Columns for the printed report
                string name = "Name";
                string shift = "Shift";
                string role = "Role";


                table.RowGroups.Add(new TableRowGroup());
                table.RowGroups[0].Rows.Add(new TableRow());
                TableRow row = table.RowGroups[0].Rows[0];
                row.Cells.Add(new TableCell(t));
                row.Cells[0].Padding = new Thickness(0,5,0,10);
                table.RowGroups[0].Rows.Add(new TableRow());
                row.Cells[0].ColumnSpan = 3;

                fd.ColumnWidth = printDlg.PrintableAreaWidth;
                fd.ColumnGap = 10.0;

                //Create a new row for the column headers
                table.RowGroups[0].Rows.Add(new TableRow());
                row = table.RowGroups[0].Rows[1];

                //Create a new entry for name column and then position it correctly in the table
                Paragraph n = new Paragraph(new Run(name));
                row.Cells.Add(new TableCell(n));
                n.FontSize = 24;
                row.Cells[0].Padding = new Thickness(0, 10, 0, 10);

                //Create a new entry for shift column and then position it correctly in the table
                Paragraph s = new Paragraph(new Run(shift));
                row.Cells.Add(new TableCell(s));
                row.Cells[1].Padding = new Thickness(0, 10, 0, 10);
                s.FontSize = 24;

                //Create a new entry for role column and then position it correctly in the table
                Paragraph r = new Paragraph(new Run(role));
                row.Cells.Add(new TableCell(r));
                row.Cells[2].Padding = new Thickness(0, 10, 0, 10);
                r.FontSize = 24;
                //Now add the data from the Listview
                table.RowGroups[0].Rows.Add(new TableRow());
                Paragraph u = new Paragraph();

                foreach (DataRowView item in schedule.ItemsSource)
                {
                    //Get the name, shift, and role from the datagrid
                    string employeeName = (string)item[0];
                    shift = (string)item[1];
                    role = (string)item[2];
                    //If employee name is somehow empty, skip it
                    if (employeeName.Length == 0)
                    {
                        continue;
                    }

                    table.RowGroups.Add(new TableRowGroup());
                    table.RowGroups[0].Rows.Add(new TableRow());
                    row = table.RowGroups[0].Rows[currentRow];

                    //Add each field to the cell in the table
                    row.Cells.Add(new TableCell(new Paragraph(new Run(employeeName))));
                    row.Cells.Add(new TableCell(new Paragraph(new Run(shift))));
                    row.Cells.Add(new TableCell(new Paragraph(new Run(role))));

                    currentRow++;
                }
                fd.Name = "Schedule";
                IDocumentPaginatorSource idpSource = fd;
                //Print the dialog to the specific location
                printDlg.PrintDocument(idpSource.DocumentPaginator, "Today's Schedule");
                System.Windows.MessageBox.Show("The Print completed!");
            }
        }

        private void printschedule_click(object sender, RoutedEventArgs e)
        {
            //Page. = new Views.ShowSchedule();
            ShowSchedule ss = new Views.ShowSchedule();
            ss.PrintSButton_Click(null, null);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
