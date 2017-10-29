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
        SqlConnection con = new SqlConnection("user id=chanc; " +
                                              "password=password;server=(localdb)\\MSSQLLocalDB; " +
                                              "Trusted_Connection=yes; " +
                                              "database=dbo; " +
                                              "connection timeout=30");
        public MainWindow()
        {
            InitializeComponent();
            con.Open();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Chance causes merge conflict.");

            Console.WriteLine("Change 1");
            Console.WriteLine("Change 2");
            Console.WriteLine("Change 3");
            Console.WriteLine("Chance's Change");
            Console.WriteLine("Hello this is Eric typing something");
            Console.WriteLine("Here 1");
            SqlCommand cmd = new SqlCommand("insert into table1 (Name) values ('Me')", con);
            cmd.ExecuteNonQuery(); 
        }
    }
}
