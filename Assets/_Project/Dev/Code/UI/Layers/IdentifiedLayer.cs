using System;
using UnityEngine;

namespace PizzaMaker.Code.UI.Layers
{
    [Serializable]
    public struct IdentifiedLayer
    {
        public LayerId Id;
        public GameObject[] Elements;
    }
}