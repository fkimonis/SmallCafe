using System;
using System.Collections.Generic;
using System.Linq;

namespace SmallCafe
{

    public class Drink
    {
        public string Type { get; set; }
        public string Description { get; set; }

        public bool HasMilk { get; set; }
        public bool HasSugar { get; set; }


        public decimal Cost { get; set; }
        
        // Calculate initial cost + toppings & ingredience
        public decimal RunningTotal { get; set; }

        // Toppings gallore
        public List<Ingredient> Toppings;
        // List to hold Milk, Sugar etc
        public List<Ingredient> Ingredients;


        public Drink()
        { 
            Toppings =  new List<Ingredient>();
            Ingredients =  new List<Ingredient>();
        }

        public decimal TotalCost()       
        {
            RunningTotal += Cost;
            RunningTotal += Ingredients.Sum(t => t.Cost);
            RunningTotal += Toppings.Sum(t => t.Cost);
            
            return RunningTotal;
        }

        public void Prepare()
        {
            string message = "We are preparing the following drink for you: " + Description;

            if (this.Ingredients.Any(n => n.Name == "Milk"))
                message += " with milk ";
            else
                message += " without milk";

            if (this.Ingredients.Any(n => n.Name == "Sugar"))
                message += " with sugar";
            else
                message += " without sugar";
            
            if (Toppings != null)
                message += " with " + String.Join(", ", Toppings.Select(x => x.Name));

           
            message += " Cost " + TotalCost().ToString("{0.00}");
            Console.WriteLine(message);
        }
    }

}
