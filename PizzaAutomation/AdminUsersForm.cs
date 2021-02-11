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
    public partial class AdminUsersForm : Form
    {
        public AdminUsersForm()
        {
            InitializeComponent();
            refreshUsers();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count < 1)
                return;
            int userID = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[0].Value);
            string username = dgvUsers.SelectedRows[0].Cells[1].Value.ToString();
            if (username == "admin")
                return;
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter("@1",userID),
                new MySqlParameter("@2",username)
            };
            int r = updateTable("DELETE FROM users WHERE id=@1 and username=@2", parameters);
            if (r > 0)
            {
                MessageBox.Show("User succesfully deleted.");
            }
            else
            {
                MessageBox.Show("User could not be deleted.");
            }
            refreshUsers();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = txtAddUsername.Text;
            string name = txtAddName.Text;
            string pass = ComputeSha256Hash(txtAddPass.Text);
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter("@1",username),
                new MySqlParameter("@2",name),
                new MySqlParameter("@3",pass)
            };
            int r = updateTable("INSERT INTO `users`(`username`, `name`, `password`) VALUES (@1,@2,@3)", parameters);
            if (r > 0)
            {
                MessageBox.Show("User succesfully added.");
            }
            else
            {
                MessageBox.Show("User could not be added.");
            }
            refreshUsers();
        }
        private void refreshUsers()
        {
            DataTable users = selectTable("select id,username,name from users");
            dgvUsers.DataSource = users.DefaultView;
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count < 1)
                return;
            int userID = Convert.ToInt32(lblUpdateUserID.Text);
            string name = txtUpdateName.Text;
            string pass = ComputeSha256Hash(txtUpdatePass.Text);
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter("@1",name),
                new MySqlParameter("@2",pass),
                new MySqlParameter("@3",userID )
            };
            int r = updateTable("UPDATE users SET name=@1,password=@2 WHERE id=@3",parameters);
            if (r > 0)
            {
                MessageBox.Show("User succesfully updated.");
            }
            else
            {
                MessageBox.Show("User could not be updated.");
            }
            refreshUsers();
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count < 1)
                return;
            var selectedRow = dgvUsers.SelectedRows[0].Cells;
            lblUpdateUserID.Text = selectedRow[0].Value.ToString();
            lblUpdateUsername.Text = selectedRow[1].Value.ToString();
            txtUpdateName.Text = selectedRow[2].Value.ToString();
        }
    }
}
