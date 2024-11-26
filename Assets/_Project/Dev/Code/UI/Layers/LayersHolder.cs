using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LayersHolder : MonoBehaviour
{
    [SerializeField] private List<IdentifiedLayer> _layersList = new();
    
    public Dictionary<LayerId, GameObject[]> Layers =>
        _layersList.ToDictionary(x => x.Id, x => x.Elements);
}