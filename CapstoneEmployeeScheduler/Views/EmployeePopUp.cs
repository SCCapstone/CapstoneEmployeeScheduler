using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapstoneEmployeeScheduler.Views
{
    public partial class EmployeeModal : Form
    {
        public EmployeeModal()
        {
            InitializeComponent();
        }

        private void absentButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void disableButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        static EmployeeModal EModal;
        static DialogResult result = DialogResult.No;

        public static DialogResult Show()
        {
            EModal = new EmployeeModal();
            EModal.ShowDialog();
            return result;

        }

        private void EmployeeModal_Load(object sender, EventArgs e)
        {

        }
    }
}
