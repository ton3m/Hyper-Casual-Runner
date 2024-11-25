using UnityEngine;

internal class FinishLayer : MonoBehaviour
{
    [SerializeField] private GameObject _winWindow;
    [SerializeField] private GameObject _loseWindow;
    
    public void OpenWinWindow() => _winWindow.SetActive(true);
    
    public void OpenLoseWindow() => _loseWindow.SetActive(true);
    
    public void CloseAllWindows()
    {
        _winWindow.SetActive(false);
        _loseWindow.SetActive(false);
    }
}