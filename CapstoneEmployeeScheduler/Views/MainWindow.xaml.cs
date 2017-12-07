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
        
        public MainWindow()
        {
            InitializeComponent();
            
            //con.Open();
        }
        
private void Employees_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = new Views.Employees();
        }

        private void TestingBackend_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Views.TestingBackend();
        }

        private void Main_Navigated(object sender, NavigationEventArgs e)
        {
            // Not sure what this does, but taking it out crashes program
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = new Views.Roles();
        }

        private void History_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = new Views.History();
        }

        private void logout_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            MessageBox.Show("You have successfully logged out.", "Logout Successful");
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Under Construction. Please check back at a later time :)", "Generate Schedule");
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            //Based on our design, Generate schedule may have to be on its own page that we can name "Home"
            Main.Content = new Views.HomePage();
        }
    }
}
