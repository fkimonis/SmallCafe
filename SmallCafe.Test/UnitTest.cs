using System;
using Xunit;
using FluentAssertions;
using SmallCafe;

namespace SmallCafe.Test
{
   
    public class TestIngredient
    {
        [Fact]
        public void Test_SmallCafe_IceTeaWithMilk()
        {
            var beverage = SmallCafe.OrderDrink("IceTea", true, true);
            beverage.Should().BeNull();
        }


        [Fact]
        public void Test_Order_Non_Existent_Drink()
        {
            var beverage = SmallCafe.OrderDrink("Latte", true, true);
            beverage.Should().BeNull();
        }

        [Fact]
        public void Test_Check_Ingredients_Added()
        {
            var beverage = SmallCafe.OrderDrink("Expresso", true, true);

            beverage.Ingredients.Contains(new Ingredient { Name = "Sugar", Cost = 0.5m });
            beverage.Ingredients.Contains(new Ingredient { Name = "Milk", Cost = 0.5m });

        }

        [Theory]
        [InlineData("IceTea", 1.5)]
        [InlineData("Expresso", 2.1)]
        [InlineData("HotTea", 1)]
        public void Test_RunningTotalIsCorrect(string type, decimal expectedcost)
        {
            var drink = SmallCafe.OrderDrink(type, false, false);
            drink.RunningTotal.Should().Equals(expectedcost);

        }

        [Theory]
        [InlineData("Expresso", 2.6)]
        [InlineData("HotTea", 1.5)]
        public void Test_CostOfDrinkWithMilkIsCorrect(string type, decimal expectedcost)
        {
            var drink = SmallCafe.OrderDrink(type, true, false);
            drink.RunningTotal.Should().Equals(expectedcost);

        }

        [Theory]
        [InlineData("Expresso", 2.6)]
        [InlineData("HotTea", 1.5)]
        public void Test_CostOfDrinkWithSugarIsCorrect(string type, decimal expectedcost)
        {
            var drink = SmallCafe.OrderDrink(type,false, true);
            drink.RunningTotal.Should().Equals(expectedcost);

        }

        [Theory]
        [InlineData("Expresso", 2.9)]
        [InlineData("HotTea", 1.8)]
        public void Test_CostOfDrinkWithMilkAndSugarIsCorrect(string type, decimal expectedcost)
        {
            var drink = SmallCafe.OrderDrink(type, false, true);
            drink.RunningTotal.Should().Equals(expectedcost);

        }
    }
}
