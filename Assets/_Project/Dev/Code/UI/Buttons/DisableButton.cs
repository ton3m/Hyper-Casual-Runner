using UnityEngine;

namespace PizzaMaker.Code.UI.Buttons
{
    public class DisableButton : ActionButton
    {
        [SerializeField] private GameObject _targetObject;

        protected override void OnClicked() => _targetObject.SetActive(false);
    }
}