using System.Collections;
using System.Collections.Generic;
using CourseGame.Develop.DI;
using PizzaMaker.Code.Services;
using UnityEngine;

namespace PizzaMaker.Code.EntryPoint
{
    public class Bootstrap : MonoBehaviour
    {
        public IEnumerator Run(DIContainer container)
        {
            Debug.Log("Game Bootstrap started");

            var curtain = container.Resolve<ILoadingCurtain>();

            curtain.Show();

            yield return EnterGameplay(new DIContainer(container));
            
            curtain.Hide();

            Debug.Log("Game Bootstrap finished.");
        }
        
        private IEnumerator EnterGameplay(DIContainer container)
        {
            var levelIndex = 0;
            
            GameplayBootstrapArgs args = new(levelIndex);
            
            var bootstrap = new GameplayBootstrap();
            
            yield return bootstrap.Run(new DIContainer(container), args);
        }
    }
}