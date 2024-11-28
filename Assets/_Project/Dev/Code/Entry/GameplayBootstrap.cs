using System;
using System.Collections;
using PizzaMaker.Code.Services.Scene;
using UnityEngine;

namespace PizzaMaker.Code.Entry
{
    public class GameplayBootstrap
    {
        public IEnumerator Run(DIContainer container, GameplayBootstrapArgs args)
        {
            Debug.Log("Gameplay bootstrapper started.");
            
            yield return LoadLevel(container, args);
            
            Debug.Log("Gameplay bootstrapper finished.");
        }

        private IEnumerator LoadLevel(DIContainer container, GameplayBootstrapArgs args)
        {
            var loader = container.Resolve<ISceneLoader>();
            
            yield return loader.LoadAsync(args.Level);
            
            var levelBootstrap = UnityEngine.Object.FindAnyObjectByType<LevelBootstrap>();
            
            if (levelBootstrap == null)
                throw new NullReferenceException(nameof(LevelBootstrap));
            
            yield return levelBootstrap.Run(container, "Hi");
        }
    }
}