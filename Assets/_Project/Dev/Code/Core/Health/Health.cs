using System;
using UnityEngine;

namespace PizzaMaker.Code.Core
{
    public class Health : IHealth
    {
        public event Action<float> Changed;
        public event Action Died;
    
        private float _value;
        private readonly float _maxValue;

        public Health(float maxValue)
        {
            _maxValue = maxValue;
            _value = maxValue;
        }
    
        public Health(float maxValue, float value)
        {
            _maxValue = maxValue;
        
            if (value > _maxValue)
                throw new ArgumentException("Current health cannot be greater than max health");
        
            _value = value;
        }
    
        public float Value => _value;
        public float MaxValue => _maxValue;

        public void ApplyDamage(float amount)
        {
            if (amount < 0)
                throw new ArgumentException("Damage value cannot be negative");
        
            if (IsDead() || amount == 0) return;
        
            _value -= amount;
            _value = Mathf.Clamp(_value, 0, _maxValue);
        
            Changed?.Invoke(_value);
        
            if (IsDead()) Died?.Invoke();
        }

        public void Heal(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Heal amount cannot be negative");
        
            if (IsDead() || amount == 0) return;
        
            _value += amount;
            _value = Mathf.Clamp(_value, 0, _maxValue);
        
            Changed?.Invoke(_value);
        }

        public bool IsDead() => Value <= 0;
    }
}