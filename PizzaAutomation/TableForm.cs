using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PizzaAutomation.DBConnection;
using Newtonsoft.Json;

namespace PizzaAutomation
{
    public partial class TableForm : Form
    {
        DefaultPizza selectedPizza = new DefaultPizza();
        OrderedPizza orderedPizza = new OrderedPizza();
        TableOrder tableOrder = new TableOrder();
        Beverage selectedBev = new Beverage();
        int TableID { get; set; }
        public TableForm(int tableId)
        {
            InitializeComponent();
            TableID = tableId;
            lblTable.Text += tableId;
            DataTable pizzas = selectTable("select pizzas.id,pizzas.name,pizzas.ingredients,sizes.name size,sizes.id sizeid,pizzas.price from pizzas join sizes on size=sizes.id");
            DataTable ingredients = selectTable("select * from ingredients");
            DataTable beverages = selectTable("select * from beverages");
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter("@1", tableId)
            };

            DataTable lastOrder = selectTable("select * from table_status where table_number=@1", parameters);
            if (lastOrder.Rows.Count > 0 && lastOrder.Rows[0]["status"].ToString() == "Busy")
            {
                tableOrder = JsonConvert.DeserializeObject<TableOrder>(lastOrder.Rows[0][2].ToString());
            }

            foreach (DataRow item in ingredients.Rows)
            {
                Ingredient ingredient = new Ingredient(Convert.ToInt32(item[0]), item[1].ToString(), Convert.ToDecimal(item[2]));
                Globals.IngredientList.Add(ingredient);
            }

            foreach (DataRow item in pizzas.Rows)
            {
                cmbSelectPizza.Items.Add(item["id"] + "~" + item["name"] + "(" + item["size"] + ")");
                DefaultPizza pizza = new DefaultPizza();
                pizza.ID = Convert.ToInt32(item["id"]);
                pizza.Name = item["name"].ToString();
                Size size = new Size();
                size.ID = Convert.ToInt32(item["sizeid"]);
                size.Name = item["size"].ToString();
                pizza.Size = size;
                pizza.Price = Convert.ToDecimal(item["price"]);
                List<int> ingredientIDs = JsonConvert.DeserializeObject<List<int>>(item["ingredients"].ToString());
                pizza.Ingredients = ingredientIDs;
                Globals.DefaultPizzaList.Add(pizza);
            }

            foreach (DataRow item in beverages.Rows)
            {
                cmbBeverages.Items.Add(item["id"] + "~" + item["name"]);
                Beverage bev = new Beverage();
                bev.ID = Convert.ToInt32(item["id"]);
                bev.Name = item["name"].ToString();
                bev.Price = Convert.ToDecimal(item["price"]);
                Globals.BeverageList.Add(bev);
            }
            refreshOrder();
        }

        private void cmbSelectPizza_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelectPizza.SelectedIndex == -1)
                return;
            dgvIngredients.Rows.Clear();
            int selectedPizzaID = Convert.ToInt32(cmbSelectPizza.SelectedItem.ToString().Split('~')[0]);
            selectedPizza = Globals.DefaultPizzaList.First(p => p.ID == selectedPizzaID);
            foreach (var ingredient in Globals.IngredientList)
            {
                int chckStat = 0;
                if (selectedPizza.Ingredients.Contains(ingredient.ID))
                {
                    chckStat = 1;
                }
                dgvIngredients.Rows.Add(chckStat, ingredient.ID, ingredient.Name, ingredient.Price);
            }
            orderedPizza.def_pizza = selectedPizza;
            refreshPizzaLabel();
        }

        private void cmbBeverages_SelectedIndexChanged(object sender, EventArgs e)
        {
            int bevID = Convert.ToInt32(cmbBeverages.SelectedItem.ToString().Split('~')[0]);
            selectedBev = Globals.BeverageList.First(p => p.ID == bevID);
            lblBeveragePrice.Text = selectedBev.Price + " TL";
        }

        private void dgvIngredients_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvIngredients.SelectedRows.Count == 0)
                return;
            orderedPizza.Ingredients.Clear();
            foreach (DataGridViewRow row in dgvIngredients.Rows)
            {
                int check = Convert.ToInt32(row.Cells[0].Value);
                int ingredientID = Convert.ToInt32(row.Cells[1].Value);
                if (check == 1 && !selectedPizza.Ingredients.Contains(ingredientID) && !orderedPizza.Ingredients.Any(p => p.ID == ingredientID))
                {
                    Ingredient ingredient = Globals.IngredientList.First(p => p.ID == ingredientID);
                    orderedPizza.Ingredients.Add(ingredient);
                }
            }
            refreshPizzaLabel();
        }

        private void dgvIngredients_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
                dgvIngredients.EndEdit();
        }

        private void btnAddPizza_Click(object sender, EventArgs e)
        {
            if (cmbSelectPizza.SelectedIndex == -1) return;
            tableOrder.OrderedPizzas.Add(orderedPizza);
            refreshOrder();
            saveOrderToDB();
        }

        private void btnAddBeverage_Click(object sender, EventArgs e)
        {
            if (cmbBeverages.SelectedIndex == -1) return;
            tableOrder.OrderedBeverages.Add(selectedBev);
            refreshOrder();
            saveOrderToDB();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                string orderType = dgvOrders.SelectedRows[0].Cells[0].Value.ToString();
                decimal price = Convert.ToDecimal(dgvOrders.SelectedRows[0].Cells[2].Value);
                switch (orderType)
                {
                    case "Pizza":
                        string pizzaName = dgvOrders.SelectedRows[0].Cells[1].Value.ToString().Split('-')[0];
                        string pizzaSize = dgvOrders.SelectedRows[0].Cells[1].Value.ToString().Split('-')[1];
                        OrderedPizza pizzaToBeRemoved = tableOrder.OrderedPizzas.First(p => p.def_pizza.Name == pizzaName && p.Price == price);
                        tableOrder.OrderedPizzas.Remove(pizzaToBeRemoved);
                        refreshOrder();
                        saveOrderToDB();
                        break;
                    case "Beverage":
                        string bevName = dgvOrders.SelectedRows[0].Cells[1].Value.ToString();
                        Beverage bevToBeRemoved = tableOrder.OrderedBeverages.First(p => p.Name == bevName && p.Price == price);
                        tableOrder.OrderedBeverages.Remove(bevToBeRemoved);
                        refreshOrder();
                        saveOrderToDB();
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (tableOrder.Price != 0)
            {
                DateTime theDate = DateTime.Now;
                theDate.ToString("yyyy-MM-dd H:mm:ss");
                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("@1",TableID)
                };
                updateTable("update `table_status` set `status`='Available', `order`='{}' where `table_number`=@1", parameters);
                List<MySqlParameter> parameters2 = new List<MySqlParameter>()
                {
                    new MySqlParameter("@1", TableID),
                    new MySqlParameter("@2", theDate),
                    new MySqlParameter("@3", JsonConvert.SerializeObject(tableOrder))
                };
                updateTable("INSERT INTO `table_records`(`table_number`, `date`, `orders`) VALUES (@1,@2,@3)", parameters2);
                MessageBox.Show("Order Completed.");
                Close();
            }

        }

        private void refreshOrder()
        {
            dgvOrders.Rows.Clear();
            foreach (var item in tableOrder.OrderedPizzas)
            {
                dgvOrders.Rows.Add("Pizza", item.def_pizza.Name + "-" + item.def_pizza.Size.Name, item.Price);
            }
            foreach (var item in tableOrder.OrderedBeverages)
            {
                dgvOrders.Rows.Add("Beverage", item.Name, item.Price);
            }
            lblTotalPrice.Text = tableOrder.Price + " TL";
            lblPizzaCount.Text = tableOrder.OrderedPizzas.Count.ToString();
            lblBeverageCount.Text = tableOrder.OrderedBeverages.Count.ToString();
        }

        private void saveOrderToDB()
        {
            if (selectTable("select * from table_status where table_number=@1", new List<MySqlParameter>() { new MySqlParameter("@1", TableID) }).Rows.Count == 0)
            {
                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("@1",TableID),
                    new MySqlParameter("@2","Busy"),
                    new MySqlParameter("@3",JsonConvert.SerializeObject(tableOrder))
                };
                updateTable("INSERT INTO `table_status`(`table_number`, `status`, `order`) VALUES (@1,@2,@3)", parameters);
            }
            else
            {
                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("@1",JsonConvert.SerializeObject(tableOrder)),
                    new MySqlParameter("@2",TableID)
                };
                updateTable("UPDATE `table_status` SET `order`=@1, `status`='Busy' where table_number=@2", parameters);
            }
        }

        private void refreshPizzaLabel()
        {
            lblPizzaPrice.Text = orderedPizza.Price + " TL";
        }

    }
}
