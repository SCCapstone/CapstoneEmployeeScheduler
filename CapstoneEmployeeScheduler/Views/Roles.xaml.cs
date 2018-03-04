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
using CapstoneEmployeeScheduler.Views;
using CapstoneEmployeeScheduler.Controllers;
using CapstoneEmployeeScheduler.Model;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace CapstoneEmployeeScheduler.Views
{
    /// <summary>
    /// Interaction logic for Roles.xaml
    /// </summary>
    public partial class Roles : Page
    {
              
        public Roles()
        {
            InitializeComponent();
            RoleController r = new RoleController();
            List<Role> item = new List<Role>();
            item = r.getAllRoles();
            role.ItemsSource = item;
            
        }
                
        private void NewRole_Click(object sender, RoutedEventArgs e)
        {
            RolesModal m = new Views.RolesModal();
            m.ShowDialog();
            //Make button work with form
            InitializeComponent();
            RoleController r = new RoleController();
            List<Role> item = new List<Role>();
            item = r.getAllRoles();
            role.ItemsSource = item;
        }

        private void role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
    }
}
