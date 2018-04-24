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
using CapstoneEmployeeScheduler.Models;
using CapstoneEmployeeScheduler.Controllers;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using System.ComponentModel;
//using System.Windows.Forms;

namespace CapstoneEmployeeScheduler.Views
{
    /// <summary>
    /// Interaction logic for Employees.xaml
    /// </summary>
    public partial class Employees : Page
    {
        public Employees()
        {
            InitializeComponent();
            ShowTable();
        }

        public void ShowTable()
        {
            //method to show the table of users and emails since every method uses it
            UserController u = new UserController();
            List<User> items = new List<User>();
            items = u.getAllUsersWithoutRoles();
            Users.ItemsSource = items;
        }

        private void NewEmployee_Click(object sender, RoutedEventArgs e)
        {
            //Calls popup to create a new employee
            RoleController r = new RoleController();
            if (r.getAllRoles().Count == 0)
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                //Does not let user create employee if no roles have been created
                System.Windows.MessageBox.Show("There are no Roles in the database. Please create a Role and then try again.", "Error", button, icon);
            }
            else
            {
                EmployeeModal m = new Views.EmployeeModal();
                m.ShowDialog();
                InitializeComponent();
                ShowTable();
            }
        }

        private void EmployeeTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Nothing goes here
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Nothing goes here
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            //This method is called when the edit button is pressed on one of the employees

            if (Users.SelectedItems.Count >= 1)
            {
                foreach (User user in Users.SelectedItems)
                {
                    //If multiple users have been selected, edit each individually
                    //Gets the id of the employee being edited and sends it to the modal
                    int id = user.Id;
                    editEmployeeModal em = new Views.editEmployeeModal(id);
                    em.ShowDialog();
                }
            }
            ShowTable();
            //Rehide the buttons so it doesnt crash the program
            DeleteButton.Visibility = Visibility.Hidden;
            EditButton.Visibility = Visibility.Hidden;
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //Method to delete user from the database
            UserController uc = new UserController();
            
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Are you sure you want to delete user(s)? This can not be undone!", "WARNING", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (User user in Users.SelectedItems)
                {
                    //If Multiple users are selected, delete them all
                    int userID = user.Id;
                    uc.deleteUserById(userID);
                }
                System.Windows.MessageBox.Show("User(s) has been deleted.");
                ShowTable();
                //Rehide edit and delete buttons
                DeleteButton.Visibility = Visibility.Hidden;
                EditButton.Visibility = Visibility.Hidden;
            }
            else if (dialogResult == DialogResult.No)
            {
                //Do nothing if they do not want to delete user
            }
            
        }

        private void Users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //If the user selects something in the table, make the edit and delete buttons visible and selectable
            if (Users.SelectedIndex >= 0)
            {
                DeleteButton.Visibility = Visibility.Visible;
                DeleteButton.IsEnabled = true;
                EditButton.Visibility = Visibility.Visible;
                EditButton.IsEnabled = true;

            }
        }

        public void PrintEButton_Click(object sender, RoutedEventArgs e)
        {
            //Method for printing table of employees
            System.Windows.Controls.PrintDialog printDlg = new System.Windows.Controls.PrintDialog();

            Nullable<bool> result = printDlg.ShowDialog();
            //Process save file dialog box results
            if (result == true)
            {
                FlowDocument fd = new FlowDocument();
                //Title of Page
                Paragraph t = new Paragraph(new Run("Current Employees"));
                t.FontSize = 36;
                t.TextAlignment = TextAlignment.Center;
                fd.Blocks.Add(t);

                fd.ColumnWidth = printDlg.PrintableAreaWidth;
                fd.ColumnGap = 10.0;
                int padding = 45;
                //Create the titles at the top of the printed page
                string name = "Name";
                Paragraph l = new Paragraph(new Run(String.Format("{0}{1}", name.PadRight(padding), "Email")));
                l.FontSize = 24;
                l.TextAlignment = TextAlignment.Left;
                fd.Blocks.Add(l);
                

                //Now add the users and emails
                Paragraph u = new Paragraph();
                string username = " ";
                string email = " ";
                int maxLength = 20;
                foreach (User item in Users.Items)
                {
                    username = item.userName;
                    email = item.email;
                    if (username.Length >= maxLength)
                    {
                        username = username.Substring(0, maxLength);
                        username = username.PadRight(maxLength - username.Length);

                    }
                    else
                    {
                        username = username.PadRight((maxLength - username.Length)-1);
                        //username = username.Substring(0, username.Length);
                        username = username + "\t";

                    }
                    //fd.Blocks.Add(new Paragraph(new Run(item.userName)));
                    u = new Paragraph(new Run(username + "\t\t\t" + email));
                    u.TextAlignment = TextAlignment.Left;
                    fd.Blocks.Add(u);
                }

                fd.Name = "Employees";
                IDocumentPaginatorSource idpSource = fd;
                //printDlg.ShowDialog();
                printDlg.PrintDocument(idpSource.DocumentPaginator, "List of Employees");
                MessageBoxButton button = MessageBoxButton.OK;
                System.Windows.MessageBox.Show("The Print method completed!", "Capstone Employee Scheduler", button);
            }


        }

        public void CSVEButton_Click(object sender, RoutedEventArgs e)
        {
            //Employee Export
            string connection = (string)System.Windows.Application.Current.FindResource("Connection");
            string queryString = "SELECT * from Users;";
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText: queryString, selectConnectionString: connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, srcTable: "Users");
            DataTable data = ds.Tables[0];

            // Configure save file dialog box
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            string filename = "";
            dlg.FileName = "Users"; // Default file name
            dlg.DefaultExt = ".csv"; // Default file extension
            dlg.Filter = "csv Files (.csv)|*.csv"; // Filter files by extension
            filename = dlg.FileName;

            Nullable<bool> result = dlg.ShowDialog();
            //Process save file dialog box results
            if (result == true)
            {
                //Save document
                filename = dlg.FileName;
                CreateCSVFile(data, filename);
            }
        }

        void CreateCSVFile(DataTable dtDataTablesList, string strFilePath)
        {
            if (strFilePath.Equals(""))
            {
                //Do nothing if there is no file name(i.e. they hit cancel)
            }
            else
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
                MessageBoxButton button = MessageBoxButton.OK;
                System.Windows.MessageBox.Show("CSV File created!", "Created!", button);
            }
        }

        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection = ListSortDirection.Ascending;
        private void NameColumn_Click(object sender, RoutedEventArgs e)
        {
            //When clicked, sort the ListView by name
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            ReorderColumn(headerClicked);
        }

        private void EmailColumn_Click(object sender, RoutedEventArgs e)
        {
            //When clicked, sort the ListView by email
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            ReorderColumn(headerClicked);
        }

        private void ShiftColumn_Click(object sender, RoutedEventArgs e)
        {
            //When clicked, sort the ListView by shift
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            ReorderColumn(headerClicked);
        }

        private void ReorderColumn(GridViewColumnHeader headerClicked)
        {
            //Main method to reorder the columns as each on uses the same thing
            ListSortDirection direction;

            if (headerClicked != null)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    if (headerClicked != _lastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (_lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }

                    var columnBinding = headerClicked.Column.DisplayMemberBinding as System.Windows.Data.Binding;
                    var sortBy = columnBinding?.Path.Path ?? headerClicked.Column.Header as string;

                    //Call method to sort data
                    Sort(sortBy, direction);

                    if (direction == ListSortDirection.Ascending)
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowUp"] as DataTemplate;
                    }
                    else
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowDown"] as DataTemplate;
                    }

                    // Remove arrow from previously sorted header  
                    if (_lastHeaderClicked != null && _lastHeaderClicked != headerClicked)
                    {
                        _lastHeaderClicked.Column.HeaderTemplate = null;
                    }

                    //Keeps track of the last header and direction
                    _lastHeaderClicked = headerClicked;
                    _lastDirection = direction;
                }
            }
        }

        private void Sort(string sortBy, ListSortDirection direction)
        {
            //Method to sort columns depending on direction received
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(Users.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }


    }


}
