namespace PizzaMaker.Code.Core.Ingredients.Abstraction
{
    public interface IInventoryView
    {
        void Add(IngredientId id, int count);
    }
}