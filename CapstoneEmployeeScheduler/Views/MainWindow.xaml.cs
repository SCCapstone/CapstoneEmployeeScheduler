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
using System.Data.SqlClient;


namespace CapstoneEmployeeScheduler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    {
        /*SqlConnection con = new SqlConnection("user id=chanc; " +
                                              "password=password;server=(localdb)\\MSSQLLocalDB; " +
                                              "Trusted_Connection=yes; " +
                                              "database=Dev; " +
                                              "connection timeout=30");*/
        public MainWindow()
        {
            InitializeComponent();
            //con.Open();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var u = this.TryFindResource("DatabaseUsername");
            var p = this.TryFindResource("DatabasePassword");
            var s = this.TryFindResource("DatabaseServer");
            var n = this.TryFindResource("DatabaseName");
            Console.WriteLine(u);
            Console.WriteLine(p);
            Console.WriteLine(s);
            Console.WriteLine(n);
            //SqlCommand cmd = new SqlCommand("insert into table1 (Name) values ('Me')", con);
            //cmd.ExecuteNonQuery(); 
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MessageBox.Show("You have successfully logged out.");
            
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new History();
        }

   

       

        private void Employees_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = new Views.Employees();
        }

        private void TestingBackend_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Views.TestingBackend();
        }
    }
}
