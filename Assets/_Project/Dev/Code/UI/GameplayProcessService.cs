using UnityEngine;

public class GameplayProcessService : IGameplayProcessService
{
    public void Start()
    {
        Debug.Log("Start");
        GameManager.Instance.gameStarted = true;
    }

    public void Stop()
    {
        Debug.Log("Stop");
    }
}