using System;

namespace PizzaMaker.Code.UI.Buttons
{
    public class StartGameButton : ActionButton
    {
        private Action _action;

        public void Initialize(Action start) => _action = start;
        
        protected override void OnClicked() => _action.Invoke();
    }
}