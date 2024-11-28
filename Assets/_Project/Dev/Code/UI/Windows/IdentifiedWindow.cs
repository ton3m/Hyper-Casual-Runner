﻿using System;
using UnityEngine;

namespace PizzaMaker.Code.UI.Windows
{
    [Serializable]
    public struct IdentifiedWindow
    {
        public WindowId Id;
        public GameObject Window;
    }
}