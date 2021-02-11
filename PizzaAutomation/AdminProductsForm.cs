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
    public partial class AdminProductsForm : Form
    {
        public AdminProductsForm()
        {
            InitializeComponent();
            refreshGlobals();
            refreshDGVs();
        }
        private void refreshGlobals()
        {
            Globals.BeverageList.Clear();
            Globals.DefaultPizzaList.Clear();
            Globals.IngredientList.Clear();
            Globals.SizeList.Clear();
            DataTable pizzas = selectTable("select pizzas.id,pizzas.name,pizzas.ingredients,sizes.name size,sizes.id sizeid,pizzas.price from pizzas join sizes on size=sizes.id");
            DataTable ingredients = selectTable("select * from ingredients");
            DataTable beverages = selectTable("select * from beverages");
            DataTable sizes = selectTable("select * from sizes");
            foreach (DataRow item in ingredients.Rows)
            {
                Ingredient ingredient = new Ingredient(Convert.ToInt32(item[0]), item[1].ToString(), Convert.ToDecimal(item[2]));
                Globals.IngredientList.Add(ingredient);
            }
            foreach (DataRow item in pizzas.Rows)
            {
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
                Beverage bev = new Beverage();
                bev.ID = Convert.ToInt32(item["id"]);
                bev.Name = item["name"].ToString();
                bev.Price = Convert.ToDecimal(item["price"]);
                Globals.BeverageList.Add(bev);
            }
            foreach (DataRow item in sizes.Rows)
            {
                Size size = new Size();
                size.ID = Convert.ToInt32(item["id"]);
                size.Name = item["name"].ToString();
                Globals.SizeList.Add(size);
            }
        }
        private void refreshDGVs()
        {
            dgvAddPizzaIngredients.Rows.Clear();
            dgvUpdatePizzaIngredients.Rows.Clear();
            dgvPizzas.Rows.Clear();
            dgvIngredients.Rows.Clear();
            dgvBeverages.Rows.Clear();
            cmbAddPizzaSize.Items.Clear();
            cmbUpdatePizzaSize.Items.Clear();
            foreach (var item in Globals.IngredientList)
            {
                dgvAddPizzaIngredients.Rows.Add(0, item.ID, item.Name);
                dgvIngredients.Rows.Add(item.ID, item.Name, item.Price);
                dgvUpdatePizzaIngredients.Rows.Add(0, item.ID, item.Name);
            }
            foreach (var item in Globals.DefaultPizzaList)
            {
                dgvPizzas.Rows.Add(item.ID, item.Name, item.Size.Name, item.Price);
            }
            foreach (var item in Globals.BeverageList)
            {
                dgvBeverages.Rows.Add(item.ID, item.Name, item.Price);
            }
            foreach (var item in Globals.SizeList)
            {
                cmbAddPizzaSize.Items.Add(item.Name);
                cmbUpdatePizzaSize.Items.Add(item.Name);
            }
        }

        private void btnAddPizza_Click(object sender, EventArgs e)
        {
            string name = txtAddPizzaName.Text;
            string strSize = cmbAddPizzaSize.SelectedItem.ToString();
            int sizeID = Globals.SizeList.First(p => p.Name == strSize).ID;
            List<int> ingredients = new List<int>();
            foreach (DataGridViewRow item in dgvAddPizzaIngredients.Rows)
            {
                if (Convert.ToInt32(item.Cells[0].Value) == 1)
                {
                    Ingredient ing = Globals.IngredientList.First(p => p.ID == Convert.ToInt32(item.Cells[1].Value));
                    ingredients.Add(ing.ID);
                }
            }
            decimal price = Convert.ToDecimal(txtAddPizzaPrice.Text);
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter("@1",name),
                new MySqlParameter("@2",JsonConvert.SerializeObject(ingredients)),
                new MySqlParameter("@3",sizeID),
                new MySqlParameter("@4",price)
            };
            int r = updateTable("INSERT INTO `pizzas`(`name`, `ingredients`, `size`, `price`) VALUES (@1,@2,@3,@4)", parameters);
            if (r > 0)
                MessageBox.Show("Pizza added.");
            else
                MessageBox.Show("Pizza could not be added.");
            refreshGlobals();
            refreshDGVs();
        }

        private void btnUpdatePizza_Click(object sender, EventArgs e)
        {
            if (dgvPizzas.SelectedRows.Count < 1)
                return;
            string name = txtUpdatePizzaName.Text;
            string strSize = cmbUpdatePizzaSize.SelectedItem.ToString();
            int sizeID = Globals.SizeList.First(p => p.Name == strSize).ID;
            List<int> ingredients = new List<int>();
            foreach (DataGridViewRow item in dgvUpdatePizzaIngredients.Rows)
            {
                if (Convert.ToInt32(item.Cells[0].Value) == 1)
                {
                    Ingredient ing = Globals.IngredientList.First(p => p.ID == Convert.ToInt32(item.Cells[1].Value));
                    ingredients.Add(ing.ID);
                }
            }
            decimal price = Convert.ToDecimal(txtUpdatePizzaPrice.Text);
            int pizzaID = Convert.ToInt32(dgvPizzas.SelectedRows[0].Cells[0].Value);
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter("@1", name),
                new MySqlParameter("@2", JsonConvert.SerializeObject(ingredients)),
                new MySqlParameter("@3", sizeID),
                new MySqlParameter("@4", price),
                new MySqlParameter("@5", pizzaID)
            };
            int r = updateTable("UPDATE `pizzas` SET name=@1,ingredients=@2,size=@3,price=@4 where id=@5", parameters);
            if (r > 0)
                MessageBox.Show("Pizza updated.");
            else
                MessageBox.Show("Pizza could not be updated.");
            refreshGlobals();
            refreshDGVs();
        }

        private void dgvPizzas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPizzas.SelectedRows.Count < 1) 
                return;
            foreach (DataGridViewRow item in dgvUpdatePizzaIngredients.Rows)
            {
                item.Cells[0].Value = 0;
            }
            int pizzaID = Convert.ToInt32(dgvPizzas.SelectedRows[0].Cells[0].Value);
            DefaultPizza selectedPizza = Globals.DefaultPizzaList.First(p => p.ID == pizzaID);
            txtUpdatePizzaName.Text = selectedPizza.Name;
            txtUpdatePizzaPrice.Text = selectedPizza.Price.ToString();
            cmbUpdatePizzaSize.SelectedItem = selectedPizza.Size.Name;
            foreach (DataGridViewRow item in dgvUpdatePizzaIngredients.Rows)
            {
                int ingID = Convert.ToInt32(item.Cells[1].Value);
                if (selectedPizza.Ingredients.Contains(ingID))
                    item.Cells[0].Value = 1;
            }

        }

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            string name = txtAddIngredientName.Text;
            decimal price = Convert.ToDecimal(txtAddIngredientPrice.Text);
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter("@1", name),
                new MySqlParameter("@2", price)
            };
            int r = updateTable("INSERT INTO `ingredients`(`name`, `price`) VALUES (@1,@2)", parameters);
            if (r > 0)
                MessageBox.Show("Ingredient added.");
            else
                MessageBox.Show("Ingredient could not be added.");
            refreshGlobals();
            refreshDGVs();
        }

        private void btnUpdateIngredient_Click(object sender, EventArgs e)
        {
            if (dgvIngredients.SelectedRows.Count < 1)
                return;
            int ingID = Convert.ToInt32(dgvIngredients.SelectedRows[0].Cells[0].Value);
            string name = txtUpdateIngredientName.Text;
            decimal price = Convert.ToDecimal(txtUpdateIngredientPrice.Text);
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter("@1", name),
                new MySqlParameter("@2", price),
                new MySqlParameter("@3", ingID)
            };
            int r = updateTable("UPDATE `ingredients` SET name=@1,price=@2 where id=@3", parameters);
            if (r > 0)
                MessageBox.Show("Ingredient updated.");
            else
                MessageBox.Show("Ingredient could not be updated.");
            refreshGlobals();
            refreshDGVs();
        }

        private void dgvIngredients_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvIngredients.SelectedRows.Count < 1)
                return;
            txtUpdateIngredientName.Text = dgvIngredients.SelectedRows[0].Cells[1].Value.ToString();
            txtUpdateIngredientPrice.Text = dgvIngredients.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void btnAddBeverage_Click(object sender, EventArgs e)
        {
            string name = txtAddBeverageName.Text;
            decimal price = Convert.ToDecimal(txtAddBeveragePrice.Text);
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter("@1", name),
                new MySqlParameter("@2", price)
            };
            int r = updateTable("INSERT INTO `beverages`(`name`, `price`) VALUES (@1,@2)", parameters);
            if (r > 0)
                MessageBox.Show("Beverage added.");
            else
                MessageBox.Show("Beverage could not be added.");
            refreshGlobals();
            refreshDGVs();
        }

        private void btnUpdateBeverage_Click(object sender, EventArgs e)
        {
            if (dgvBeverages.SelectedRows.Count < 1)
                return;
            int bevID = Convert.ToInt32(dgvBeverages.SelectedRows[0].Cells[0].Value);
            string name = txtUpdateBeverageName.Text;
            decimal price = Convert.ToDecimal(txtUpdateBeveragePrice.Text);
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter("@1", name),
                new MySqlParameter("@2", price),
                new MySqlParameter("@3", bevID)
            };
            int r = updateTable("UPDATE `beverages` SET name=@1,price=@2 where id=@3", parameters);
            if (r > 0)
                MessageBox.Show("Beverage updated.");
            else
                MessageBox.Show("Beverage could not be updated.");
            refreshGlobals();
            refreshDGVs();
        }

        private void btnDeletePizza_Click(object sender, EventArgs e)
        {
            if (dgvPizzas.SelectedRows.Count < 1)
                return;
            int pizzaID = Convert.ToInt32(dgvPizzas.SelectedRows[0].Cells[0].Value);
            int r = updateTable("DELETE FROM pizzas where id=@1", new List<MySqlParameter> {new MySqlParameter("@1",pizzaID) });
            if (r > 0)
                MessageBox.Show("Pizza deleted.");
            else
                MessageBox.Show("Pizza could not be deleted.");
            refreshGlobals();
            refreshDGVs();
        }

        private void btnDeleteIngredient_Click(object sender, EventArgs e)
        {
            if (dgvIngredients.SelectedRows.Count < 1)
                return;
            int ingID = Convert.ToInt32(dgvIngredients.SelectedRows[0].Cells[0].Value);
            int r = updateTable("DELETE FROM ingredients where id=@1", new List<MySqlParameter> { new MySqlParameter("@1", ingID) });
            if (r > 0)
                MessageBox.Show("Ingredient deleted.");
            else
                MessageBox.Show("Ingredient could not be deleted.");
            refreshGlobals();
            refreshDGVs();
        }

        private void btnDeleteBeverage_Click(object sender, EventArgs e)
        {
            if (dgvBeverages.SelectedRows.Count < 1)
                return;
            int bevID = Convert.ToInt32(dgvBeverages.SelectedRows[0].Cells[0].Value);
            int r = updateTable("DELETE FROM beverages where id=@1", new List<MySqlParameter> { new MySqlParameter("@1", bevID) });
            if (r > 0)
                MessageBox.Show("Beverage deleted.");
            else
                MessageBox.Show("Beverage could not be deleted.");
            refreshGlobals();
            refreshDGVs();
        }

        private void dgvBeverages_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBeverages.SelectedRows.Count < 1)
                return;
            txtUpdateBeverageName.Text = dgvBeverages.SelectedRows[0].Cells[1].Value.ToString();
            txtUpdateBeveragePrice.Text = dgvBeverages.SelectedRows[0].Cells[2].Value.ToString();
        }
    }
}
