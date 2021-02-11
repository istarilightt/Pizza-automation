using MySql.Data.MySqlClient;
using Newtonsoft.Json;
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

namespace PizzaAutomation
{
    public partial class AdminIncomeForm : Form
    {
        public AdminIncomeForm()
        {
            InitializeComponent();
        }

        Dictionary<int, TableOrder> orders = new Dictionary<int, TableOrder>();
        private void button1_Click(object sender, EventArgs e)
        {
            orders.Clear();
            dgvRecords.Rows.Clear();
            dgvOrders.Rows.Clear();
            decimal total = 0;
            string strFirstTime = dtpFirst.Value.ToString("yyyy-MM-dd H:mm:ss");
            string strSecondTime = dtpSecond.Value.ToString("yyyy-MM-dd H:mm:ss");
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@1",strFirstTime),
                new MySqlParameter("@2",strSecondTime)
            };
            DataTable result = selectTable("select * from table_records where date between @1 and @2", parameters);
            foreach (DataRow item in result.Rows)
            {
                TableOrder to = JsonConvert.DeserializeObject<TableOrder>(item["orders"].ToString());
                orders.Add(Convert.ToInt32(item["id"]), to);
                dgvRecords.Rows.Add(item["id"],item["date"], item["table_number"], to.Price);
                total += to.Price;
            }
            txtTotal.Text = total.ToString();
        }

        private void dgvRecords_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRecords.SelectedRows.Count < 1)
                return;
            int id = Convert.ToInt32(dgvRecords.SelectedRows[0].Cells[0].Value);
            dgvOrders.Rows.Clear();
            TableOrder tableOrder = orders[id];
            foreach (var item in tableOrder.OrderedPizzas)
            {
                dgvOrders.Rows.Add("Pizza", item.def_pizza.Name + "-" + item.def_pizza.Size.Name, item.Price);
            }
            foreach (var item in tableOrder.OrderedBeverages)
            {
                dgvOrders.Rows.Add("Beverage", item.Name, item.Price);
            }
        }
    }
}
