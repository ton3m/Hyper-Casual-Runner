using System;

public class UIStateMachine
{
    public event Action MenuStateEntered;
    public event Action GameStateEntered;
    public event Action FinishStateEntered;
    
    private readonly LayersActivator _layersActivator;

    public UIStateMachine(LayersActivator layersActivator)
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