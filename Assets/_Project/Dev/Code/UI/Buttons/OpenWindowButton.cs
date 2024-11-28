using System;
using PizzaMaker.Code.Services.UI;
using PizzaMaker.Code.UI.Windows;
using UnityEngine;

namespace PizzaMaker.Code.UI.Buttons
{
    public class OpenWindowButton : ActionButton
    {
        [SerializeField] private WindowId _windowId;
        private IWindowsService _windowsService;

        public void Initialize(IWindowsService windowsService) => 
            _windowsService = windowsService;

        protected override void OnClicked() => _windowsService.Open(_windowId);
    }
}

