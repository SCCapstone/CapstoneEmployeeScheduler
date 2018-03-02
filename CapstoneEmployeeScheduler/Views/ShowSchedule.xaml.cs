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

namespace CapstoneEmployeeScheduler.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    /// 
     
    
    
    public partial class ShowSchedule : Window
    {

        DataGridView dt = new DataGridView();
        int numberofEmployees = CapstoneEmployeeScheduler.Algorithm.makeSchedule.userCount;

        public ShowSchedule()
        {
            //InitializeComponent();
            
            AddCols();
            AddRows();
            WriteRows();
            
        }

        private void AddCols()
        {
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = "Employee";
            textColumn.Binding = new System.Windows.Data.Binding("Employee");
            dataGridView1.Columns.Add(textColumn);
        }

        private void AddRows()
        {
            for(int i =0; i < numberofEmployees; i++)
            {
                dt.Rows.Add();
            }
        }

        private void WriteRows()
        {
           dataGridView1.ItemsSource = dt;
        }
    }
}
