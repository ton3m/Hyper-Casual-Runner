using System.Collections.Generic;
using System.Linq;
using PathCreation.Examples;
using UnityEngine;

public class UIRoot : MonoBehaviour
{
    [SerializeField] private WindowsHolder _windowsHolder;
    [SerializeField] private LayersHolder _layersHolder;

    private UIStateMachine _stateMachine;
    private WindowsService _windowsService;

    private List<LevelProgressBar> _levelProgressBars = new();

    private void Awake()
    {
        _windowsService = new WindowsService(_windowsHolder.Windows);
        var layersActivator = new LayersActivator(_layersHolder.Layers);

        _stateMachine = new UIStateMachine(layersActivator);
        _stateMachine.GameStateEntered += () => GameManager.Instance.gameStarted = true;


        InitElements(_windowsService);
    }

    private void Start() => _stateMachine.EnterMenuState();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) HandleWinLose(true);

        _levelProgressBars.ForEach(bar => bar.UpdateProgress(PathFollower.Instance.pathProgress));
    }

    private void HandleWinLose(bool isWin)
    {
        _stateMachine.EnterFinishState();

        _windowsService.Open(isWin ? WindowId.Win : WindowId.Lose);
    }

    private void InitElements(WindowsService windowsService)
    {
        List<OpenWindowButton> openWindowButtons = GetComponentsInChildren<OpenWindowButton>(true).ToList();
        List<StartGameButton> startGameButtons = GetComponentsInChildren<StartGameButton>(true).ToList();
        _levelProgressBars = GetComponentsInChildren<LevelProgressBar>(true).ToList();

        startGameButtons.ForEach(button => button.Initialize(_stateMachine.EnterGameState));
        openWindowButtons.ForEach(button => button.Initialize(windowsService));
    }
}