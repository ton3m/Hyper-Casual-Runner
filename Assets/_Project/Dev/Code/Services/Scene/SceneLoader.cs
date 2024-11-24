using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PizzaMaker.Code.Services
{
    public class SceneLoader : ISceneLoader
    {
        public IEnumerator LoadAsync(SceneId sceneId, LoadSceneMode mode = LoadSceneMode.Single)
        {
            var operation = SceneManager.LoadSceneAsync(sceneId.ToString(), mode);
            
            if (operation == null)
                throw new ArgumentException($"Scene {sceneId} not found in build scene list");
            
            yield return operation;
            Debug.Log($"Scene {sceneId} loaded.");
        }
    }

    public interface IInputSceneArgs
    {
    }

    public class GameplayInputArgs : IInputSceneArgs
    {
        public GameplayInputArgs(int level)
        {
            Level = level;
        }

        public int Level { get; }
    }

    public class MainMenuInputArgs : IInputSceneArgs
    {
    }

    public interface IOutputSceneArgs
    {
        IInputSceneArgs NextSceneInputArgs { get; }
    }

    public abstract class OutputSceneArgs : IOutputSceneArgs
    {
        protected OutputSceneArgs(IInputSceneArgs nextSceneInputArgs)
        {
            NextSceneInputArgs = nextSceneInputArgs;
        }

        public IInputSceneArgs NextSceneInputArgs { get; }
    }

    public class OutputGameplayArgs : OutputSceneArgs
    {
        public OutputGameplayArgs(IInputSceneArgs nextSceneInputArgs) : base(nextSceneInputArgs)
        {
        }
    }

    public class OutputMenuArgs : OutputSceneArgs
    {
        public OutputMenuArgs(IInputSceneArgs nextSceneInputArgs) : base(nextSceneInputArgs)
        {
        }
    }

    public class OutputBootstrapArgs : OutputSceneArgs
    {
        public OutputBootstrapArgs(IInputSceneArgs nextSceneInputArgs) : base(nextSceneInputArgs)
        {
        }
    }
}