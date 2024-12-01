using System;
using System.Collections.Generic;
using System.Linq;
using PizzaMaker.Code.Services.GameFinishDetector;
using PizzaMaker.Code.Services.UI;
using PizzaMaker.Code.UI.Buttons;
using PizzaMaker.Code.UI.Layers;
using PizzaMaker.Code.UI.Windows;
using UnityEngine;

namespace PizzaMaker.Code.UI
{
    public class UIRoot : MonoBehaviour
    {
        public IGameUIStatesEvents Events => _stateMachine;
        
        private List<LevelProgressBar> _levelProgressBars = new();
        private LayersStateMachine _stateMachine;
        
        private IWindowsService _windowsService;
        private IGameFinishDetector _gameFinishDetector;
        private ILayersActivator _layersActivator;
        private Func<float> _getLevelProgress;
        
        public void Init(
            IGameFinishDetector gameFinishDetector,
            IWindowsService windowsService,
            ILayersActivator layersActivator,
            Func<float> getLevelProgress)
        {
            _getLevelProgress = getLevelProgress;
            _layersActivator = layersActivator;
            _gameFinishDetector = gameFinishDetector;
            _windowsService = windowsService;
            
            _stateMachine = new LayersStateMachine(_layersActivator);
        }

        public void Enable()
        {
            _gameFinishDetector.Finished += HandleWinLose;
        
            InitElements();
        
            _stateMachine.EnterMenuState();
        }

        private void Update()
        {
            _levelProgressBars?.ForEach(bar =>
                bar.UpdateProgress(_getLevelProgress?.Invoke() ?? 0f));
        }

        private void HandleWinLose(GameResult result)
        {
            _stateMachine.EnterFinishState();

            _windowsService.Open(result.IsWin ? WindowId.Win : WindowId.Lose);
        }

        private void InitElements()
        {
            List<OpenWindowButton> openWindowButtons = GetComponentsInChildren<OpenWindowButton>(true).ToList();
            List<StartGameButton> startGameButtons = GetComponentsInChildren<StartGameButton>(true).ToList();
            _levelProgressBars = GetComponentsInChildren<LevelProgressBar>(true).ToList();

            startGameButtons.ForEach(button => button.Initialize(_stateMachine.EnterGameState));
            openWindowButtons.ForEach(button => button.Initialize(_windowsService));
        }
    }
}