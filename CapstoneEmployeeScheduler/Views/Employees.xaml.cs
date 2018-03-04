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
using CapstoneEmployeeScheduler.Model;
using CapstoneEmployeeScheduler.Controllers;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace CapstoneEmployeeScheduler.Views
{
    /// <summary>
    /// Interaction logic for Employees.xaml
    /// </summary>
    public partial class Employees : Page
    {
        public Employees()
        {
            //code to display the table with all the employees
            InitializeComponent();
            ShowTable();
        }

        private void NewEmployee_Click(object sender, RoutedEventArgs e)
        {
            //calls popup to create a new employee
            EmployeeModal m = new Views.EmployeeModal();
            m.ShowDialog();
            InitializeComponent();
            ShowTable();
        }

        private void EmployeeTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Not sure what this method does, but the application crashes without this method for some reason ¯\_(ツ)_/¯
        }

        public void ShowTable()
        {
            //method to show the table of users and emails since every method uses it
            UserController u = new UserController();
            List<User> items = new List<User>();
            items = u.getAllUsers();
            Users.ItemsSource = items;
        }
        

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            //This method is called when the edit button is pressed on one of the employees
            
            User u= (User) Users.SelectedItem;
            int id = u.Id;
            //gets the id of the employee being edited and sends it to the modal
            editEmployeeModal em = new Views.editEmployeeModal(id);
            em.ShowDialog();
            ShowTable();
        }

        private void Users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Not sure what this does, but the application crashes without this method for some reason ¯\_(ツ)_/¯
            if (Users.SelectedIndex >= 0)
            {
                //dunno why this is here
            }
        }

        private void PrintEButton_Click(object sender, RoutedEventArgs e)
        {
            //method for printing table of employees
            //TODO: once schedule is able to be displayed, move to schedule
            PrintDialog printDlg = new PrintDialog();
            if(printDlg.ShowDialog() == true)
            {
                printDlg.PrintVisual(Users, "List of Employees");
            }
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
