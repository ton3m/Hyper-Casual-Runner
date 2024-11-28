using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using PizzaMaker.Code.Services.GameFinishDetector;
using PizzaMaker.Code.Services.Scene;
using PizzaMaker.Code.Services.UI;
using PizzaMaker.Code.UI.Layers;
using PizzaMaker.Code.UI;
using PizzaMaker.Code.UI.Windows;
using UnityEngine;

namespace PizzaMaker.Code.Entry 
{
    public class LevelBootstrap : BaseLevelBootstrap
    {
        private DIContainer _container;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        private static void LoadEntryScene()
        {
            var sceneLoader = new SceneLoader();
            sceneLoader.Load(SceneId.Bootstrap);
        }
        
        public override IEnumerator Run(DIContainer container, object args)
        {
            _container = container;

            Debug.Log("Level bootstrap started.");
            Debug.Log("Level bootstrap args: " + args);

            InitUI();
            
            Debug.Log("Level bootstrap finished.");
            
            yield break;
        }

        private void InitUI()
        {
            var uiRoot = FindAnyObjectByType<UIRoot>();
            
            Dictionary<WindowId, GameObject> windows = FindAnyObjectByType<WindowsHolder>()?.Windows;
            Dictionary<LayerId, GameObject[]> layers = FindAnyObjectByType<LayersHolder>()?.Layers;
            
            GameFinishDetector2 gameFinishDetector = new(() => false, null);
            
            IWindowsService windowsService = new WindowsService(windows);
            ILayersActivator layersActivator = new LayersActivator(layers);

            uiRoot.Init(
                gameFinishDetector,
                windowsService,
                layersActivator,
                () => PathFollower.Instance.pathProgress);

            uiRoot.Enable();
        }
    }
}