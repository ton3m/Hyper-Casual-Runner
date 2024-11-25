using UnityEngine;

public class OpenWindowButton : ActionButton
{
    [SerializeField] private WindowId _windowId;

    public void Initialize(IWindowsService windowsService) => 
        SetOnClicked(() => windowsService.Open(_windowId));
}

