using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IWindowsService
{
    void Open(WindowId id);
}


public enum WindowId
{
    Settings,
    Win,
    Lose
}

public class WindowsService : IWindowsService
{
    private readonly Dictionary<WindowId, GameObject> _windows;
    
    public WindowsService(Dictionary<WindowId, GameObject> windows)
    {
        _windows = windows;
    }
    
    public void Open(WindowId id)
    {
        if (_windows.TryGetValue(id, out var window))
        {
            window.SetActive(true);
        }
    }
}

public interface IUIFactory
{
    void CreateSettings();
    void CreateWin();
    void CreateLose();
}

public class WindowFactory : IUIFactory
{
    public void CreateSettings()
    {
        throw new NotImplementedException();
    }

    public void CreateWin()
    {
        throw new NotImplementedException();
    }

    public void CreateLose()
    {
        throw new NotImplementedException();
    }
}

public class MenuEvents : IDisposable
{
    public event Action SettingsButtonClicked = delegate { };
    public event Action StartButtonClicked = delegate { };
   
    private readonly Button.ButtonClickedEvent _settingsButtonEvent;
    private readonly Button.ButtonClickedEvent _startButtonEvent;

    public MenuEvents(Button settingsButton, Button startButton)
    {
        _settingsButtonEvent = settingsButton.onClick;
        _startButtonEvent = startButton.onClick;
        
        _settingsButtonEvent.AddListener(() => SettingsButtonClicked?.Invoke());
        _startButtonEvent.AddListener(() => StartButtonClicked?.Invoke());
    }
    
    public void Dispose()
    {
        _settingsButtonEvent.RemoveAllListeners();
        _startButtonEvent.RemoveAllListeners();
    }
}