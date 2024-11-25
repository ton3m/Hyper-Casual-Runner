using UnityEngine;
using UnityEngine.UI;


public class MenuLayer : MonoBehaviour
{
    [SerializeField] private Button _settings;
    [SerializeField] private Button _start;
    [SerializeField] private GameObject _settingsWindow;
    [SerializeField] private GameObject _tutorial;
    
    public event System.Action SettingsButtonClicked;
    public event System.Action StartButtonClicked;
    
    public void ShowSettingsWindow() => _settingsWindow.SetActive(true);
    
    public void HideSettingsWindow() => _settingsWindow.SetActive(false);
    
    public void ShowTutorial() => _tutorial.SetActive(true);
    
    public void HideTutorial() => _tutorial.SetActive(false);
    
    public void ShowButtons()
    {
        _settings.gameObject.SetActive(true);
        _start.gameObject.SetActive(true);
    }
    
    public void HideButtons()
    {
        _settings.gameObject.SetActive(false);
        _start.gameObject.SetActive(false);
    }
    
    private void OnEnable()
    {
        _settings.onClick.AddListener(() => SettingsButtonClicked?.Invoke());
        _start.onClick.AddListener(() => StartButtonClicked?.Invoke());
    }
    
    private void OnDisable()
    {
        _settings.onClick.RemoveAllListeners();
        _start.onClick.RemoveAllListeners();
    }
}