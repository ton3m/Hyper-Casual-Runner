using System.Collections;
using CourseGame.Develop.DI;
using UnityEngine;

namespace PizzaMaker.Code.EntryPoint
{
    public class LevelBootstrap : BaseLevelBootstrap
    {
        private DIContainer _container;

        public override IEnumerator Run(DIContainer container, object args)
        {
            _container = container;
            
            Debug.Log("Level bootstrap started.");
            
            yield return new WaitForSeconds(1f);
            
            Debug.Log("Level bootstrap args: " + args);
            
            Debug.Log("Level bootstrap finished.");
        }
    }

    public abstract class BaseLevelBootstrap : MonoBehaviour
    {
        public abstract IEnumerator Run(DIContainer container, object args);
    }
}