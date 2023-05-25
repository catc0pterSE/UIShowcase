using System;
using SceneObjects;
using UI.Menu;
using UnityEngine;
using UnityEngine.UI;
using Utility.Constants;
using Object = UnityEngine.Object;

namespace ObjectSpawning
{
    public class GameObjectFactory
    {
        private readonly AssetProvider _assetProvider;

        public GameObjectFactory(AssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public Cube CreateCube(Vector3 at) =>
            Object.Instantiate(_assetProvider.Provide<Cube>(ResourcePaths.CubePath), at, Quaternion.identity) ??
            throw NotFindException(typeof(Cube));

        public GridSpawner CreateGridSpawner() =>
            Object.Instantiate(_assetProvider.Provide<GridSpawner>(ResourcePaths.GridSpawner)) ??
            throw NotFindException(typeof(GridSpawner));

        public ObjectCard CreateObjectCard(LayoutGroup parent) =>
            Object.Instantiate(_assetProvider.Provide<ObjectCard>(ResourcePaths.ObjectCard), parent.transform) ??
            throw NotFindException(typeof(ObjectCard));


        private NullReferenceException NotFindException(Type objectType) =>
            new NullReferenceException($"Can't find {objectType} object");
    }
}