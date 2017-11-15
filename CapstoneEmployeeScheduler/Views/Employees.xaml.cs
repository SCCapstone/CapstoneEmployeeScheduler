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
        }

        private void NewEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeModal.Show();
            //Make button work with form
        }

    }


}
