using System.Collections;
using CourseGame.Develop.DI;
using PizzaMaker.Code.Services;
using UnityEngine;

namespace PizzaMaker.Code.EntryPoint
{
    public class Bootstrap : MonoBehaviour
    {
        public IEnumerator Run(DIContainer container)
        {
            //init all services, data, configs, ads, analytics, etc
            
            var curtain = container.Resolve<ILoadingCurtain>();
            curtain.Show();
            
            Debug.Log("Bootstrap started");
            
            yield return new WaitForSeconds(3); //service init example
            
            Debug.Log("Bootstrap finished");
            curtain.Hide();
            
            //transition to next scene
        }
    }
}