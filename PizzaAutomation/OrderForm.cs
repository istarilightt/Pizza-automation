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
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        private void table_8_Click(object sender, EventArgs e)
        {
            string strTableid = ((Button)sender).Name.Split('_').Last();
            int tableid = 0;
            Int32.TryParse(strTableid, out tableid);
            if (tableid != 0)
            {
                //
            }
        }
    }
}
