using System;
using UnityEngine;

public class UIStateChanger : MonoBehaviour
{
    [SerializeField] private MenuLayer _menuLayer;
    [SerializeField] private GameLayer _gameLayer;
    [SerializeField] private FinishLayer _finishLayer;
    
    public event Action GameStateEntered;

    private void Awake() => EnterMenuState();

    public void EnterMenuState()
    {
        HideGameLayer();
        ShowMenuLayer();
    }

    public void EnterGameState()
    {
        HideMenuLayer();
        ShowGameLayer();
        
        GameStateEntered?.Invoke();
    }

    private void ShowMenuLayer()
    {
        _menuLayer.ShowButtons();
        _menuLayer.ShowTutorial();
    }

    private void HideMenuLayer()
    {
        _menuLayer.HideSettingsWindow();
        _menuLayer.HideButtons();
        _menuLayer.HideTutorial();
    }

    private void HideGameLayer() => _gameLayer.HideProgressBar();

    private void ShowGameLayer() => _gameLayer.ShowProgressBar();

    public void EnterFinishState()
    {
        HideGameLayer();
        HideMenuLayer();
            
        ShowWinLayer();
    }

    private void ShowWinLayer()
    {
        throw new System.NotImplementedException();
    }
}