using System;

namespace PizzaMaker.Code.Services.GameFinishDetector
{
    public interface IGameFinishDetector
    {
        event Action<GameResult> Finished;
    }
}