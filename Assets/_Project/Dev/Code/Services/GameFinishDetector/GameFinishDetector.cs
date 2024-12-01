using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaMaker.Code.Services.GameFinishDetector
{
    public class GameFinishDetector :IUpdateable, IGameFinishDetector
    {
        public event Action<GameResult> Finished;
        
        private bool _isFinished;
        
        private readonly List<Func<bool>> _winConditions = new();
        private readonly List<Func<bool>> _loseConditions = new();
        
        public GameFinishDetector(
            IEnumerable<Func<bool>> winConditions,
            IEnumerable<Func<bool>> loseConditions)
        {
            _winConditions.AddRange(winConditions);
            _loseConditions.AddRange(loseConditions);
        }
        
        public GameFinishDetector(Func<bool> winCondition, Func<bool> loseCondition)
        {
            _winConditions.Add(winCondition);
            _loseConditions.Add(loseCondition);
        }

        public GameFinishDetector()
        {
        }

        public void Update()
        {
            if (_isFinished) return;
            
            if (_winConditions.Any(condition => condition.Invoke()))
            {
                Win();
            }
            else if (_loseConditions.Any(condition => condition.Invoke()))
            {
                Lose();
            }
        }

        public void Lose()
        {
            if (_isFinished) return;
            
            _isFinished = true;
            Finished?.Invoke(GameResult.Lost);
        }

        public void Win()
        {
            if (_isFinished) return;
            
            _isFinished = true;
            Finished?.Invoke(GameResult.Won);
        }
    }
}