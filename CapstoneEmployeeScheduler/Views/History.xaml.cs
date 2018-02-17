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

namespace CapstoneEmployeeScheduler.Views
{
    /// <summary>
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : Page
    {
        public History()
        {
            InitializeComponent();
            //List<genSchedule> = new List<genSchedule>();
            List<String> items = new List<String>();
            items.Add("02/08/2018 14:25");
            GeneratedSchedules.ItemsSource = items;
        }
        
        private void CSVEButton_Click(object sender, RoutedEventArgs e)
        {
            //Employee Export
            string connection = (string)System.Windows.Application.Current.FindResource("Connection");
            string queryString = "SELECT * from Users;";
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText: queryString, selectConnectionString: connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, srcTable: "Users");
            DataTable data = ds.Tables[0];
            string path = @"C:\Users\Public\Documents\Users.csv";
            CreateCSVFile(data, path);
            System.Windows.MessageBox.Show("CSV File created. Please check your C:\\Users\\Public\\Documents.", "Created!");
        }

        private void CSVRButton_Click(object sender, RoutedEventArgs e)
        {
            //Role Export
            string connection = (string)System.Windows.Application.Current.FindResource("Connection");
            string queryString = "SELECT * from Roles;";
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText: queryString, selectConnectionString: connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, srcTable: "Roles");
            DataTable data = ds.Tables[0];
            string path = @"C:\Users\Public\Documents\Roles.csv";
            CreateCSVFile(data, path);
            System.Windows.MessageBox.Show("CSV File created. Please check your C:\\Users\\Public\\Documents.", "Created!");
        }

        void CreateCSVFile(DataTable dtDataTablesList, string strFilePath)
        {
            // Create the CSV file to which grid data will be exported.
            StreamWriter sw = new StreamWriter(strFilePath, false);
            sw.Write("sep = \t");
            sw.Write(sw.NewLine);
            //First we will write the headers.
            int iColCount = dtDataTablesList.Columns.Count;
            for (int i = 1; i < iColCount; i++)
            {
                sw.Write(dtDataTablesList.Columns[i]);
                if (i < iColCount - 1)
                {
                    sw.Write(" ");
                    sw.Write("\t");
                }
            }
            sw.Write(sw.NewLine);

            // Now write all the rows.
            foreach (DataRow dr in dtDataTablesList.Rows)
            {
                for (int i = 1; i < iColCount; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        sw.Write(dr[i].ToString());
                    }
                    if (i < iColCount - 1)
                    {
                        sw.Write(" ");
                        sw.Write("\t");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        private void view_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Will display the history from the selected date/time.", "VIEWS");
        }

        private void History_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
