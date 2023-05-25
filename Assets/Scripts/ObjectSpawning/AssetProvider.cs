using UnityEngine;

namespace ObjectSpawning
{
    public class AssetProvider
    {
        public T Provide<T>(string resourcePath) where T: Object => 
            Resources.Load<T>(resourcePath);
    }
}