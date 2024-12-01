using UnityEngine;

namespace PizzaMaker.Code.Core.Ingredients
{
    public class Ingredient : MonoBehaviour
    {
        [SerializeField] private IngredientId _id;
        
        public IngredientId Id => _id;
    }
}
