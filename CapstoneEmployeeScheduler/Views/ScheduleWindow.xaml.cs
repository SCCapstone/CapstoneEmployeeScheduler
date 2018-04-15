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
            string role = "Role";
            Paragraph l = new Paragraph(new Run(String.Format("{0}{1}{2}", name.PadRight(padding), role.PadRight(padding), "Shift")));
            l.FontSize = 24;
            l.TextAlignment = TextAlignment.Left;
            fd.Blocks.Add(l);
            int maxLength = 20;
            //Now add the data from the Listview
            Paragraph u = new Paragraph();
            foreach (DataRowView item in schedule.ItemsSource)
            {
                string employeeName = (string)item[0];
                if (employeeName.Length == 0)
                {
                    continue;
                    
                }

                name = employeeName.Substring(0, employeeName.Length);
                if (employeeName.Length >= 20)
                {
                    name = employeeName.Substring(0, 20);
                }
                else
                {
                    employeeName = employeeName.PadRight(maxLength - employeeName.Length);
                }
                //fd.Blocks.Add(new Paragraph(new Run(item.userName)));
                u = new Paragraph(new Run(name + "\t\t" + item[1] + "\t\t" + item[2]));
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
