using System.Collections;
using UnityEngine.SceneManagement;

namespace PizzaMaker.Code.Services.Scene
{
    public interface ISceneLoader
    {
        IEnumerator LoadAsync(SceneId sceneId, LoadSceneMode mode = LoadSceneMode.Single);
        void Load(SceneId sceneId, LoadSceneMode mode = LoadSceneMode.Single);
    }
}