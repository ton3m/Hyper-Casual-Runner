using System;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace PizzaMaker.Code.Core
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _valueText;
        private IHealth _health;

        public void Init(IHealth health)
        {
            _health = health;
        }

        private void Start()
        {
            if (_health == null)
                throw new NullReferenceException(nameof(_health));

            UpdateValue(_health.Value);
            _health.Changed += UpdateValue;
        }

        private void OnDestroy()
        {
            if (_health != null)
                _health.Changed -= UpdateValue;
        }

        private void UpdateValue(float value) =>
            _valueText.text = value.ToString(CultureInfo.InvariantCulture);
    }
}