using System;
using System.Collections.Generic;
using UnityEngine;

public class WindowsService : IWindowsService
{
    private readonly Dictionary<WindowId, GameObject> _windows;

    public WindowsService(Dictionary<WindowId, GameObject> windows)
    {
        _windows = windows;
    }

    public void Open(WindowId id)
    {
        if (_windows.TryGetValue(id, out GameObject window) == false) 
            throw new ArgumentException($"Window with id {id} not registered.");
        
        window.SetActive(window);
    }
}