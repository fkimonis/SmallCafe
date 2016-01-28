using FluentValidation;

namespace SmallCafe
{
    public class DrinkValidator : AbstractValidator<Drink>
    {

        public DrinkValidator()
        {
            // Check for milk in the Ice Tea
            RuleFor(m => m.HasMilk).Equal(false).When(m => m.Type == "IceTea").WithMessage("Ice Tea should not contain milk");

           //TODO: Need more work
           // RuleFor(m => m.Type).Equal("IceTea").When(m => m.Ingredient.Any(n => n.Name == "Milk")).WithMessage("Ice Tea should not contain milk");

            
        }
    }
}