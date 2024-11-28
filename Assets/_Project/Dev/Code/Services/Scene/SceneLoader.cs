using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PizzaMaker.Code.Services.Scene
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

        public void Load(SceneId sceneId, LoadSceneMode mode = LoadSceneMode.Single)
        {
            SceneManager.LoadScene(sceneId.ToString(), mode);
            
            Debug.Log($"Scene {sceneId} loaded.");
        }
    }
}