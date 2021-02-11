using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaAutomation
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminUsersForm auf = new AdminUsersForm();
            auf.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminProductsForm apf = new AdminProductsForm();
            apf.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminIncomeForm aif = new AdminIncomeForm();
            aif.ShowDialog();
        }
    }
}
