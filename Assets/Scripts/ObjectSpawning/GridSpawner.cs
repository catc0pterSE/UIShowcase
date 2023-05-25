using SceneObjects;
using UnityEngine;

namespace ObjectSpawning
{
    public class GridSpawner : MonoBehaviour
    {
        [SerializeField] private int _gridX = 10;
        [SerializeField] private int _gridY = 10;
        [SerializeField] private float _spacingOffset = 1;
        [SerializeField] private Vector3 _gridOrigin;

        private GameObjectFactory _gameObjectFactory;

        public void Initialize(GameObjectFactory gameObjectFactory)
        {
            _gameObjectFactory = gameObjectFactory;
        }

        public Cube[] SpawnCubes(int quantity)
        {
            Cube[] cubes = new Cube[quantity];

            for (int i = 0; i < quantity; i++)
            {
                int x = i % _gridX;
                int y = (i - x) / _gridY;
                cubes[i] = _gameObjectFactory.CreateCube
                (
                    _gridOrigin + new Vector3(x * _spacingOffset, -y * _spacingOffset, 0)
                );
            }

            return cubes;
        }
    }
}