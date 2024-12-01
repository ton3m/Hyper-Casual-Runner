using System;
using System.Collections.Generic;
using System.Linq;
using PizzaMaker.Code.Core;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PizzaMaker.Code.Core.Ingredients
{
    public class ViewsPull : IViewsPull
    {
        private readonly List<Ingredient> _ingredients = new();
        
        public void Add(Ingredient ingredient)
        {
            ingredient.gameObject.SetActive(false);
            ingredient.transform.parent = null;
            
            _ingredients.Add(ingredient);
        }
        
        public GameObject Get(IngredientId id)
        {
            Ingredient ingredient = _ingredients.FirstOrDefault(i => i.Id == id);
            
            if (ingredient == null)
                throw new NullReferenceException($"Ingredient view with id {id} not found.");
            
            _ingredients.Remove(ingredient);
            
            GameObject view = ingredient.gameObject;
            
            Object.Destroy(ingredient);
            
            return view;
        }
    }

    public interface IViewsPull
    {
        void Add(Ingredient ingredient);
        GameObject Get(IngredientId id);
    }
}