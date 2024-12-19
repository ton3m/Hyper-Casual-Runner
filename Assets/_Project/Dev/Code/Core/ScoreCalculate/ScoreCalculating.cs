using System;
using Unity.VisualScripting;
using UnityEngine;

namespace PizzaMaker
{
    public class ScoreCalculating
    {
        private readonly Func<float> _normalizedPosition;

        public float TotalScore { get; private set; }
        private float _timingTestScore;

        public ScoreCalculating (Func <float> normalizedPosition)
        {
            _normalizedPosition = normalizedPosition;
        }
        public void TotalScoreCalculate()
        {
            throw new System.NotImplementedException();
        }

        public void OnIndicatorStop()
        {
            float position = _normalizedPosition();
            TimingTestScoreCalculate(position);
        }

        public void TimingTestScoreCalculate(float normalizedPosition)
        {
            _timingTestScore = (1 - Mathf.Abs(normalizedPosition)) * 100;
        }
        
        public void IngredientsCostCalculate()
        {
            throw new System.NotImplementedException();
        }
        
    }
}