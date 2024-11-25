using System.Collections.Generic;
using System.Linq;
using PathCreation.Examples;
using UnityEngine;

public class UIRoot : MonoBehaviour
{
    [SerializeField] private UIStateChanger _stateChanger;
    [SerializeField] private WindowsHolder _windowsHolder;

    private List<LevelProgressBar> _levelProgressBars = new();

    private void Awake()
    {
        Dictionary<WindowId, GameObject> windows = _windowsHolder.Windows;
        var windowsService = new WindowsService(windows);

        var gameplayProcessService = new GameplayProcessService();

        _stateChanger.GameStateEntered += gameplayProcessService.Start;

        InitElements(windowsService);
    }

    private void Update()
    {
        _levelProgressBars.ForEach(bar => bar.UpdateProgress(PathFollower.Instance.pathProgress));
    }

    private void InitElements(WindowsService windowsService)
    {
        List<OpenWindowButton> openWindowButtons = GetComponentsInChildren<OpenWindowButton>(true).ToList();
        List<StartGameButton> startGameButtons = GetComponentsInChildren<StartGameButton>(true).ToList();
        _levelProgressBars = GetComponentsInChildren<LevelProgressBar>(true).ToList();

        startGameButtons.ForEach(button => button.Initialize(_stateChanger.EnterGameState));
        openWindowButtons.ForEach(button => button.Initialize(windowsService));
    }
}