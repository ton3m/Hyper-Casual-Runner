using System;
using PizzaMaker.Code.Core;

namespace PizzaMaker.Code.Core.Ingredients.Abstraction
{
    public interface IInventory
    {
        event Action<IngredientId> IngredientAdded;
        int Count { get; }
        void Add(IngredientId ingredient);
    }
}