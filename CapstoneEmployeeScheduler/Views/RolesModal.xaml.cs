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
using CapstoneEmployeeScheduler.Model;
using CapstoneEmployeeScheduler.Controllers;


namespace CapstoneEmployeeScheduler.Views
{
    /// <summary>
    /// Interaction logic for RolesModal.xaml
    /// </summary>
    public partial class RolesModal : Window
    {
        public string des;
        public RolesModal()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            RoleController r = new RoleController();
            Role role = new Role();
            role.RoleName = name.Text;
            role.RoleDescription = description.Text;
            int x = 0;
            Int32.TryParse(RoleCountBox.Text, out x);
            role.RoleCount = x;
            r.createRole(role);
            this.Close();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RoleCountBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(RoleCountBox.Text, "[^0-9]"))
                {
                MessageBox.Show("Please enter only numbers greater than zero.");
                RoleCountBox.Text = RoleCountBox.Text.Remove(RoleCountBox.Text.Length - 1);
            }
        }
    }
}
