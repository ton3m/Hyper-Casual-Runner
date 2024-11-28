using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaMaker.Code.Services.GameFinishDetector
{
    public class GameFinishDetector2 :IUpdateable, IGameFinishDetector
    {
        public event Action<GameResult> Finished;
        
        private bool _isFinished;
        
        private readonly List<Func<bool>> _winConditions = new();
        private readonly List<Func<bool>> _loseConditions = new();
        
        public GameFinishDetector2(
            IEnumerable<Func<bool>> winConditions,
            IEnumerable<Func<bool>> loseConditions)
        {
            _winConditions.AddRange(winConditions);
            _loseConditions.AddRange(loseConditions);
        }
        
        public GameFinishDetector2(Func<bool> winCondition, Func<bool> loseCondition)
        {
            _winConditions.Add(winCondition);
            _loseConditions.Add(loseCondition);
        }

        public void Update()
        {
            if (_isFinished) return;
            
            if (_winConditions.Any(condition => condition.Invoke()))
            {
                Finished?.Invoke(GameResult.Won);
                _isFinished = true;
            }
            else if (_loseConditions.Any(condition => condition.Invoke()))
            {
                Finished?.Invoke(GameResult.Lost);
                _isFinished = true;
            }
        }
    }
}