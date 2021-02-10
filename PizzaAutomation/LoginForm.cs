using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PizzaAutomation.DBConnection;
using static PizzaAutomation.Encryption;

namespace PizzaAutomation
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            if (connection.State != ConnectionState.Open)
                connection.Open();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string pass = ComputeSha256Hash(txtPass.Text);
            List<MySqlParameter> parameters = new List<MySqlParameter> {
                new MySqlParameter("@1",username),
                new MySqlParameter("@2",pass)
            };
            DataTable result = selectTable("select * from users where username=@1 and password=@2", parameters);
            if (result.Rows.Count > 0)
            {
                OrderForm formOrder = new OrderForm();
                formOrder.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
                return;
            }
        }
    }
}
