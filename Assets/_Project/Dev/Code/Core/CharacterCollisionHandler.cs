using PizzaMaker.Code.Core.Ingredients.Abstraction;
using PizzaMaker.Code.Core.Ingredients;
using UnityEngine;

namespace PizzaMaker.Code.Core
{
    public class CharacterCollisionHandler : MonoBehaviour
    {
        [SerializeField] private Transform _attachPoint;
        
        private IIngredientsCollector _ingredientsCollector;

        public void Init(IIngredientsCollector ingredientsCollector)
        {
            _ingredientsCollector = ingredientsCollector;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Ingredient ingredient))
            {
                _ingredientsCollector.Collect(ingredient);
            }
        }
    }
}