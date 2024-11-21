using UnityEngine;

namespace PizzaMaker.Code.Services
{
    public class ResourcesAssetLoader 
    {
        public T LoadResource<T>(string path) where T : Object
        {
            T resource = Resources.Load<T>(path);
            
            if (resource == null) 
                Debug.LogError($"Resource {path} not found");
            
            return resource;
        }
    }
}
