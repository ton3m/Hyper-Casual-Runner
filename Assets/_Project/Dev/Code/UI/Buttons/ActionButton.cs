using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ActionButton : MonoBehaviour
{
    private UnityAction _onClicked = null;
    private Button _button;

    private void Awake() => _button = GetComponent<Button>();
    
    private void Start()
    {
        if (_onClicked == null)
            throw new NullReferenceException(nameof(_onClicked));
        
        _button.onClick.AddListener(_onClicked);
    }

    private void OnDestroy() => _button.onClick.RemoveAllListeners();
    
    public void SetOnClicked(Action onClicked) => _onClicked = new UnityAction(onClicked);
}