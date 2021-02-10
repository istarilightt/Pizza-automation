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
    }

    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public User(int id,string username,string name,string password)
        {
            this.id = id;
            this.username = username;
            this.name = name;
            this.password = password;
        }
        public User() { }
    }
    public class Beverage
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
    }
    public class Ingredient
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public Ingredient(int _id,string _name,decimal _price)
        {
            id = _id;
            name = _name;
            price = _price;
        }
    }

    public class Size
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class DefaultPizza
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<int> Ingredients { get; set; }
        public Size size { get; set; }
        public decimal price { get; set; }
    }
    public class OrderedPizza
    {

        public DefaultPizza def_pizza { get; set; }
        public string name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public Size size { get; set; }
        public decimal price 
        {
            get
            {
                decimal _price = def_pizza.price;
                foreach (var item in Ingredients)
                {
                    if (def_pizza.Ingredients.Any(p => p == item.id))
                        continue;
                    else
                        _price += item.price;
                }
                return _price;
            }
        }
    }
}
