using System.Collections;
using UnityEngine;

namespace PizzaMaker.Code.Entry
{
    public abstract class BaseLevelBootstrap : MonoBehaviour
    {
        public abstract IEnumerator Run(DIContainer container, object args);
    }
}