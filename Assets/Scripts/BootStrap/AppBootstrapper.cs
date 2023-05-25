using ObjectSpawning;
using SceneObjects;
using UI.Menu;
using UnityEngine;

namespace BootStrap
{
    public class AppBootstrapper : MonoBehaviour
    {
        private void Awake()
        {
            AssetProvider assetProvider = new AssetProvider();
            GameObjectFactory gameObjectFactory = new GameObjectFactory(assetProvider);
            GridSpawner gridSpawner = gameObjectFactory.CreateGridSpawner();
            gridSpawner.Initialize(gameObjectFactory);
            Cube[] cubes = gridSpawner.SpawnCubes(18);
            FindObjectOfType<Menu>().Initialize(gameObjectFactory, cubes);
        }
    }
}