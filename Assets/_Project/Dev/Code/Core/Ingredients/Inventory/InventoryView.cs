using PizzaMaker.Code.Core;
using PizzaMaker.Code.Core.Ingredients.Abstraction;
using UnityEngine;

namespace PizzaMaker.Code.Core.Ingredients
{
    public class InventoryView : MonoBehaviour, IInventoryView
    {
        private ViewsPull _viewsPull;
        [SerializeField] private Transform _attachPoint;

        public void Init(ViewsPull viewsPull)
        {
            _viewsPull = viewsPull;
        }
        
        public void Add(IngredientId id, int count)
        {
            GameObject ingredient = _viewsPull.Get(id);
            
            ingredient.transform.parent = _attachPoint;

            //ingredient.transform.localScale *= 0.5f;
            var scale = ingredient.transform.localScale;
            
            scale.x *= 2;
            scale.z *= 2;
            scale.y = 0.1f;
            
            ingredient.transform.localScale = scale;
            
            float height = (count-1) * 0.1f;
            ingredient.transform.position = _attachPoint.position + Vector3.up * height;

            ingredient.gameObject.SetActive(true);
        }
    }
}