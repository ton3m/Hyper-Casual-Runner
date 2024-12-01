using System;
using UnityEngine;

namespace PizzaMaker.Code.Core
{
    public class FinishLine : MonoBehaviour, IFinishLine
    {
        public bool IsReached => _isReached;
        
        public event Action WasReached;
    
        private bool _isReached;
        
        private void OnCollisionEnter(Collision other) => Check(other.gameObject);

        private void OnTriggerEnter(Collider other) => Check(other.gameObject);

        private void Check(GameObject obj)
        {
            if (obj.GetComponent<PlayerMarker>() != null)
            {
                Debug.Log("Reached finish line.");
                WasReached?.Invoke();
                _isReached = true;
            }
        }
    }

    public interface IFinishLine
    {
        bool IsReached { get; }
        event Action WasReached;
    }
}