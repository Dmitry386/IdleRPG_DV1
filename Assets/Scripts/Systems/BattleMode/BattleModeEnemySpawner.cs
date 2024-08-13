using Assets.Scripts.Entities.Enemy;
using Assets.Scripts.Systems.BattleMode;
using DVUnityUtilities;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Systems.LevelSystems
{
    internal class BattleModeEnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private LevelSystem _levelSystem;

        [SerializeField]
        private BattleModeSystem _battleModeSystem;

        [SerializeField]
        private Transform _spawnPoint;

        [SerializeField]
        private float _interval = 5f;

        private CharacterEntity _spawned;

        private void Awake()
        {
            _battleModeSystem.OnChanged.AddListener(OnBattleModeChanged);
        }

        private void OnBattleModeChanged(BattleModeSystem arg0)
        {
            StopAllCoroutines();
            if (arg0.IsActiveBattleMode())
            {
                if (_interval > 0)
                {
                    StartCoroutine(CheckSpawnRules());
                }
            }
            else
            {
                Despawn();
            }
        }


        private IEnumerator CheckSpawnRules()
        {
            if (_spawned)
            {
                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(_interval);
                if (_battleModeSystem.IsActiveBattleMode())
                {
                    Spawn();
                }
            }
        }

        public void Spawn()
        {
            Despawn();

            if (_levelSystem.IsHaveLoadedLevel(out var level))
            {
                var enemyToSpawn = level.Enemies?.CharacterPrefabs.GetRandomElement();

                if (enemyToSpawn)
                {
                    _spawned = Instantiate(enemyToSpawn, _spawnPoint.position, _spawnPoint.rotation);
                }
                else
                {
                    Debug.LogWarning($"{nameof(level.Enemies)} is empty");
                }
            }
        }

        public void Despawn()
        {
            if (_spawned)
            {
                GameObject.Destroy(_spawned.gameObject);
            }
            _spawned = null;
        }

        private void OnDestroy()
        {
            _battleModeSystem.OnChanged.RemoveListener(OnBattleModeChanged);
        }
    }
}