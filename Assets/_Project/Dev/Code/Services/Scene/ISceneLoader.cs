using System.Collections;
using UnityEngine.SceneManagement;

namespace PizzaMaker.Code.Services
{
    public interface ISceneLoader
    {
        IEnumerator LoadAsync(SceneId sceneId, LoadSceneMode mode = LoadSceneMode.Single);
    }
}