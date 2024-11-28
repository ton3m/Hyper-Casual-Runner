using System;
using PizzaMaker.Code.UI.Layers;

namespace PizzaMaker.Code.UI
{
    public class LayersStateMachine
    {
        public event Action MenuStateEntered;
        public event Action GameStateEntered;
        public event Action FinishStateEntered;
    
        private readonly ILayersActivator _layersActivator;

        public LayersStateMachine(ILayersActivator layersActivator)
        {
            _layersActivator = layersActivator;
        }

        public void EnterMenuState()
        {
            _layersActivator.DisableAll();
            _layersActivator.Enable(LayerId.Menu);
        
            MenuStateEntered?.Invoke();
        }
    
        public void EnterGameState()
        {
            _layersActivator.DisableAll();
            _layersActivator.Enable(LayerId.Game);
        
            GameStateEntered?.Invoke();
        }
    
        public void EnterFinishState()
        {
            _layersActivator.DisableAll();
        
            FinishStateEntered?.Invoke();
        }
    }
}