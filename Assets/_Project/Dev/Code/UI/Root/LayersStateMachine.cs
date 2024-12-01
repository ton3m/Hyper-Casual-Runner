using System;
using PizzaMaker.Code.UI.Layers;

namespace PizzaMaker.Code.UI
{
    public class LayersStateMachine : IGameUIStatesEvents
    {
        public event Action MenuStateEntered;
        public event Action GameplayStateEntered;
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
        
            GameplayStateEntered?.Invoke();
        }
    
        public void EnterFinishState()
        {
            _layersActivator.DisableAll();
        
            FinishStateEntered?.Invoke();
        }
    }

    public interface IGameUIStatesEvents
    {
        event Action MenuStateEntered;
        event Action GameplayStateEntered;
        event Action FinishStateEntered;
    }
}