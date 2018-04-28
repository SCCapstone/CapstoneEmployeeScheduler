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
using CapstoneEmployeeScheduler.Models;
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
            s = sc.getScheduleByDate(DateTime.Today);

            //Create the 3 columns in the schedule
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

        public void PrintSButton_Click(object sender, RoutedEventArgs e)
        {
            //Print method for the schedule
            System.Windows.Controls.PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
            Nullable<bool> result = printDlg.ShowDialog();
            //Process print file dialog box results
            if (result == true)
            {
                FlowDocument fd = new FlowDocument();
                Table table = new Table();
                fd.Blocks.Add(table);
                

                //Title of Page
                Paragraph t = new Paragraph(new Run("Today's Schedule"));
                //Set the font size and text alignment of the title of the page and add it
                t.FontSize = 36;
                t.TextAlignment = TextAlignment.Center;

                int padding = 40;
                //Create the Columns for the printed report
                string name = "Name";
                string shift = "Shift";
                string role = "Role";
                //Paragraph l = new Paragraph(new Run(String.Format("{0}{1}{2}", name, shift, role)));
                //l.FontSize = 24;
                //l.TextAlignment = TextAlignment.Left;
                //fd.Blocks.Add(l);


                table.RowGroups.Add(new TableRowGroup());
                table.RowGroups[0].Rows.Add(new TableRow());
                TableRow row = table.RowGroups[0].Rows[0];
                row.Cells.Add(new TableCell(t));
                row.Cells[0].Padding = new Thickness(5);
                table.RowGroups[0].Rows.Add(new TableRow());
                row.Cells[0].ColumnSpan = 3;
                // fd.Blocks.Add(t);

                fd.ColumnWidth = printDlg.PrintableAreaWidth;
                fd.ColumnGap = 10.0;

                table.RowGroups[0].Rows.Add(new TableRow());
                row = table.RowGroups[0].Rows[1];
                
                //row.Cells.Add(new TableCell(l));
                //row.Cells[0].ColumnSpan = 3;
                Paragraph n = new Paragraph(new Run(name));
                row.Cells.Add(new TableCell(n));
                n.TextAlignment = TextAlignment.Left;
                n.FontSize = 24;
                row.Cells[0].Padding = new Thickness(10);
                Paragraph s = new Paragraph(new Run(shift));
                row.Cells.Add(new TableCell(s));
                //row.Cells[0].Padding = new Thickness(10);
                s.TextAlignment = TextAlignment.Left;
                s.FontSize = 24;
                Paragraph r = new Paragraph(new Run(role));
                row.Cells.Add(new TableCell(r));
                r.TextAlignment = TextAlignment.Left;
                //row.Cells[0].Padding = new Thickness(10);
                r.FontSize = 24;
                //row.Cells.Add(new TableCell(new Paragraph(new Run(shift))));
                //row.Cells.Add(new TableCell(new Paragraph(new Run(role))));

                //int maxLength = 20;
                //Now add the data from the Listview
                table.RowGroups[0].Rows.Add(new TableRow());
                Paragraph u = new Paragraph();
                int currentRow = 2;
                
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

                    table.RowGroups.Add(new TableRowGroup());
                    table.RowGroups[0].Rows.Add(new TableRow());
                    row = table.RowGroups[0].Rows[currentRow];
                    /*
                    name = employeeName;
                    if (employeeName.Length >= maxLength)
                    {
                        //If the name is longer than the preset max length, cut it off at the max to line up columns
                        employeeName = employeeName.Substring(0, maxLength);
                        //name = employeeName.PadRight((maxLength - employeeName.Length),'x');
                        name = employeeName;

                    }
                    else
                    {
                        //If under the max length, pad right with blank spaces until it reaches the max and add a tab for column lining up
                        //name = employeeName.PadRight((maxLength - employeeName.Length),'y') ;
                        name = employeeName.PadRight(maxLength, '_');
                        
                        //name = name + "\t";
                    }
                    */
                    row.Cells.Add(new TableCell(new Paragraph(new Run(employeeName))));
                    row.Cells.Add(new TableCell(new Paragraph(new Run(shift))));
                    row.Cells.Add(new TableCell(new Paragraph(new Run(role))));

                    //fd.Blocks.Add(new Paragraph(new Run(item.userName)));
                    //u = new Paragraph(new Run(name+ "\t\t\t" + shift + "\t\t\t" + role));
                    //u.TextAlignment = TextAlignment.Left;
                    //fd.Blocks.Add(u);
                    currentRow++;
                }

                fd.Name = "Schedule";
                IDocumentPaginatorSource idpSource = fd;
                //Print the dialog to the specific location
                printDlg.PrintDocument(idpSource.DocumentPaginator, "Today's Schedule");
                System.Windows.MessageBox.Show("The Print completed!");
            }
        }

        private void schedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Nothing goes here
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Nothing goes here
        }
    }
}
