using CourseGame.Develop.DI;
using PizzaMaker.Code.Services;
using UnityEngine;

namespace PizzaMaker.Code.EntryPoint
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Bootstrap _bootstrap;

        private void Awake()
        {
            SetupAppSettings();
            
            DIContainer container = new();
            
            RegResourcesAssetLoader(container);
            RegCoroutinePerformer(container);
            RegSceneLoader(container);
            
            container.Resolve<ICoroutinePerformer>().StartPerform(_bootstrap.Run(container));
        }

        private void SetupAppSettings()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }

        private void RegSceneLoader(DIContainer container)
        {
            container.RegisterAsSingle<ILoadingCurtain>(c =>
            {
                var loader = c.Resolve<ResourcesAssetLoader>();
                
                LoadingCurtain prefab = loader
                    .LoadResource<LoadingCurtain>(ResourcesPaths.LoadingCurtain);
                
                return Instantiate(prefab);
            });
        }

        private static void RegCoroutinePerformer(DIContainer container)
        {
            container.RegisterAsSingle<ICoroutinePerformer>(c =>
            {
                var loader = c.Resolve<ResourcesAssetLoader>();
                
                CoroutinePerformer prefab = loader
                    .LoadResource<CoroutinePerformer>(ResourcesPaths.CoroutinePerformer);
                
                return Instantiate(prefab);
            });
        }

        private static void RegResourcesAssetLoader(DIContainer container)
        {
            container.RegisterAsSingle(c => new ResourcesAssetLoader());
        }
    }
}