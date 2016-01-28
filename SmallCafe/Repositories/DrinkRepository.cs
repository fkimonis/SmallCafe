using System.Collections.Generic;
using log4net;

namespace SmallCafe
{
    public class DrinkRepository
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(DrinkRepository));

        public static List<Drink> drinks;
        public static List<Ingredient> ingredients;

        public DrinkRepository() {

            // Unecessary inheritance replaced with List
            // TODO: Populate from datastore
            drinks = new List<Drink>
            {
                new Drink{Type  = "Expresso", Description = "Expresso", Cost = 1.8m, 
                    Toppings = new List<Ingredient>{new Ingredient {Name = "Chocolate Topping", Cost = 0.3m }}}, 
                new Drink{Type  = "IceTea", Description = "Ice Tea", Cost = 1.5m},
                new Drink{Type  = "HotTea", Description = "Hot Tea", Cost = 1m}
            };

            // TODO: Populate from datastore
            ingredients = new List<Ingredient>
            {
                new Ingredient{Name  = "Sugar", Cost = 0.5m},
                new Ingredient{Name  = "Milk",  Cost = 0.5m}
            };

        }

        public void AddIngredient(ref Drink drink, string type) {

            //TODO: Need to deal with quantities correctly
            drink.Ingredients.Add(ingredients.Find(d => d.Name == type));

            // TODO: Remove - Only needed for finicky validator
            if (type == "Milk")
                drink.HasMilk = true;
            if (type == "Sugar")
                drink.HasSugar = true; 
        }

        public Drink GetDrink(string type)
        {

            Drink drink = drinks.Find(d => d.Type == type);
            return drink;
        }

    }
}