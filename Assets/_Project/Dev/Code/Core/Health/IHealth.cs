using System;

namespace PizzaMaker.Code.Core
{
    public interface IHealth
    {
        event Action<float> Changed;
        event Action Died;
        float Value { get; }
        float MaxValue { get; }
        void ApplyDamage(float amount);
        void Heal(int amount);
    }
}