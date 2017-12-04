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
using CsvHelper;

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
        }
        private void CSVButton_Click(object sender, RoutedEventArgs e)
        {
            string connection = (string)System.Windows.Application.Current.FindResource("Connection");
            string queryString = "SELECT * from Dev;";
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText: queryString, selectConnectionString: connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, srcTable: "Users");
            DataTable data = ds.Tables[0];
            String path = @"C:\Users\Public\Documents\MyDocument";
            CreateCSVFile(data, path);


            void CreateCSVFile(DataTable dtDataTablesList, string strFilePath)
            {
                // Create the CSV file to which grid data will be exported.
                StreamWriter sw = new StreamWriter(strFilePath, false);
                //First we will write the headers.
                int iColCount = dtDataTablesList.Columns.Count;
                for (int i = 0; i < iColCount; i++)
                {
                    sw.Write(dtDataTablesList.Columns[i]);
                    if (i < iColCount - 1)
                    {
                        sw.Write("", "");
                    }
                }
                sw.Write(sw.NewLine);

                // Now write all the rows.
                foreach (DataRow dr in dtDataTablesList.Rows)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            sw.Write(dr[i].ToString());
                        }
                        if (i < iColCount - 1)
                        {
                            sw.Write("", "");
                        }
                    }
                    sw.Write(sw.NewLine);
                }
                sw.Close();
            }

            /*
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
            {
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var sw = new StreamWriter(sfd.FileName))
                    {
                        var writer = new CsvWriter(sw);
                        writer.WriteHeader(typeof(Employees));
                        foreach(Employees a in WhateverThisIs.DataSource as List<Employees>)
                        {
                            writer.WriteRecord(a);
                        }
                    }
                }
                System.Windows.MessageBox.Show("Your Data has been Saved");
            }
            */

        }

    }
}
