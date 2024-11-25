using UnityEngine;

internal class GameLayer : MonoBehaviour
{
    [SerializeField] private LevelProgressBar _levelProgressBar;
    
    public void ShowProgressBar() => _levelProgressBar.gameObject.SetActive(true);
    
    public void HideProgressBar() => _levelProgressBar.gameObject.SetActive(false);
}