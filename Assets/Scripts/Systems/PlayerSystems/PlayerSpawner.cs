using UnityEngine;

namespace Assets.Scripts.Systems.PlayerSystems
{
    internal class PlayerSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _playerPrefab;

        [SerializeField]
        private Transform _spawnPoint;

        [SerializeField]
        private bool _spawnOnStart;

        private GameObject _spawned;

        private void Start()
        {
            if (_spawnOnStart)
            {
                Spawn();
            }
        }

        public void Spawn()
        {
            if (!_spawned)
            {
                _spawned = Instantiate(_playerPrefab, _spawnPoint.position, _spawnPoint.rotation);
            }
            else
            {
                _spawned.transform.position = _spawnPoint.position;
                _spawned.transform.rotation = _spawnPoint.rotation;
            }
        }
    }
}