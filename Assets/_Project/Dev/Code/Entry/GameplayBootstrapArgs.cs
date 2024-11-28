using System;
using PizzaMaker.Code.Services.Scene;

namespace PizzaMaker.Code.Entry
{
    public class GameplayBootstrapArgs
    {
        public SceneId Level { get; }

        public GameplayBootstrapArgs(int levelIndex)
        {
            int levelSceneId = (int)SceneId.Level1 + levelIndex;

            if (Enum.IsDefined(typeof(SceneId), levelSceneId) == false)
                throw new ArgumentException($"Provided scene {levelSceneId} is not a level");

            Level = (SceneId)levelSceneId;
        }
    }
}