using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WindowsHolder : MonoBehaviour
{
    [SerializeField] private List<IdentifiedWindow> _windows;
    
    public Dictionary<WindowId, GameObject> Windows =>
        _windows.ToDictionary(w => w.Id, w => w.Window);
}