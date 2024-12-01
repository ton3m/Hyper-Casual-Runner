using PizzaMaker.Code.Core;

namespace PizzaMaker.Code.Core.Ingredients.Abstraction
{
    public interface IIngredientsCollector
    {
        void Collect(Ingredient ingredient);
    }
}