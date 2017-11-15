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
    /// Interaction logic for Roles.xaml
    /// </summary>
    public partial class Roles : Page
    {
        public Roles()
        {
            InitializeComponent();
            //this.button1.Click += new EventHandler(button1_Click);
        }

        /*private void NewRole_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is going to be the form");
            //Make button work with form
        }*/

        private void NewRole_Click(object sender, RoutedEventArgs e)
        {
            RoleModal.Show();
            //Make button work with form
        }
    }
}
