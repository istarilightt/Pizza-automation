using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAutomation
{
    public static class Globals
    {
        public static User loggedInUser = new User();
        public static List<DefaultPizza> DefaultPizzaList = new List<DefaultPizza>();
        public static List<Beverage> BeverageList = new List<Beverage>();
        public static List<Size> SizeList = new List<Size>();
        public static List<Ingredient> IngredientList = new List<Ingredient>();
        public static Dictionary<int,TableOrder> tableOrders = new Dictionary<int, TableOrder>();
    }
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public User(int id,string username,string name,string password)
        {
            this.ID = id;
            this.Username = username;
            this.Name = name;
            this.Password = password;
        }
        public User() { }
    }
    public class Beverage
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class Ingredient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Ingredient(int _id,string _name,decimal _price)
        {
            ID = _id;
            Name = _name;
            Price = _price;
        }
    }
    public class Size
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class DefaultPizza
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<int> Ingredients { get; set; }
        public Size Size { get; set; }
        public decimal Price { get; set; }
    }
    public class OrderedPizza
    {
        public DefaultPizza def_pizza { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public decimal Price 
        {
            get
            {
                decimal _price = def_pizza.Price;
                foreach (var item in Ingredients)
                {
                    if (def_pizza.Ingredients.Any(p => p == item.ID))
                        continue;
                    else
                        _price += item.Price;
                }
                return _price;
            }
            set { }
        }
    }
    public class TableOrder
    {
        public List<OrderedPizza> OrderedPizzas { get; set; } = new List<OrderedPizza>();
        public List<Beverage> OrderedBeverages { get; set; } = new List<Beverage>();
        public decimal Price 
        {
            get
            {
                decimal _total = 0;
                OrderedPizzas.ForEach(p => _total += p.Price);
                OrderedBeverages.ForEach(p => _total += p.Price);
                return _total;
            }
        }
    }
}
