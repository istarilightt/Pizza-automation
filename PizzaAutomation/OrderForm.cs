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

namespace PizzaAutomation
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
            refreshButtons();
        }

        private void refreshButtons()
        {
            int[] tables = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            foreach (var tableId in tables)
            {
                List<MySqlParameter> parameters = new List<MySqlParameter>() { new MySqlParameter("@1", tableId) };
                DataTable tableResult = selectTable("select * from table_status where table_number=@1", parameters);
                if (tableResult != null && tableResult.Rows.Count > 0)
                {
                    if (tableResult.Rows[0]["status"].ToString() == "Available")
                    {
                        Button btn = Controls.Cast<Control>().First(p => p.Name == "table_" + tableId) as Button;
                        btn.BackColor = Color.LightSeaGreen;
                    }
                    else
                    {
                        Button btn = Controls.Cast<Control>().First(p => p.Name == "table_" + tableId) as Button;
                        btn.BackColor = Color.Yellow;
                    }
                }
                else
                {
                    Button btn = Controls.Cast<Control>().First(p => p.Name == "table_" + tableId) as Button;
                    btn.BackColor = Color.LightSeaGreen;
                }
            }
        }

        private void table_8_Click(object sender, EventArgs e)
        {
            string strTableid = ((Button)sender).Name.Split('_').Last();
            int tableid;
            Int32.TryParse(strTableid, out tableid);
            if (tableid != 0)
            {
                TableForm tf = new TableForm(tableid);
                tf.ShowDialog();
                refreshButtons();
            }
        }
    }
}
