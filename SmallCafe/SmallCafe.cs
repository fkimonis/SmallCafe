using FluentValidation.Results;
using System;
using log4net;

// Books
// http://www.goodreads.com/book/show/85009.Design_Patterns
// http://www.goodreads.com/book/show/44936.Refactoring
// http://www.goodreads.com/book/show/13629.The_Mythical_Man_Month
// 
//Blogs 
// 
// https://lostechies.com/
// https://ayende.com/blog

namespace SmallCafe
{
    public class SmallCafe
    {
      
        public static Drink OrderDrink(string type, bool hasMilk, bool hasSugar)
        {
            
            // Logger to help during development and when deployed to production
            ILog logger = LogManager.GetLogger(typeof(SmallCafe));

           

            // Moved the creation of drinks to a central location
            var drinkRepository = new DrinkRepository();
            Drink drink = drinkRepository.GetDrink(type);

            try
            
            {

                if (drink == null)
                    throw new System.InvalidOperationException("Drink type not yet available.");
               
                // Ingredients and Toppings properties
                if (hasMilk)
                    drinkRepository.AddIngredient(ref drink, "Milk");

                if (hasSugar)
                    drinkRepository.AddIngredient(ref drink, "Sugar");

                // Validators are good for keeping things tidy
                // Ideally placed in an IOC Container
                // and resolved where needed.
                DrinkValidator validator = new DrinkValidator(); 
                ValidationResult results = validator.Validate(drink);

                if (!results.IsValid)
                {
                    foreach (var failure in results.Errors)
                    {
                        // Let the barista know of any drinks issues
                        IConsoleLogger consoleLogger = new ConsoleLogger();
                        consoleLogger.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    
                    }

                    drink = null;
                }
                else
                {

                    drink.Prepare();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("We are unable to prepare your drink.");
                // Log Exception
                logger.FatalFormat(ex.Message, ex);
            }

            return drink;
        }
    }

    
}