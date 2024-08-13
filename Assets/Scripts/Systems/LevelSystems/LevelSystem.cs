using Assets.Scripts.Configs.WorldConfig;
using Assets.Scripts.Systems.LevelSystems.Events;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Systems.LevelSystems
{
    internal class LevelSystem : MonoBehaviour
    {
        [SerializeField]
        private bool _initializeOnStart;

        [SerializeField]
        private List<LevelConfig> _levels = new();

        [SerializeField]
        public UnityEvent<LevelChangeEventArgs> OnLevelChanged;

        private LevelConfig _currentLevel;

        private void Start()
        {
            if (_initializeOnStart)
            {
                Initialize();
            }
        }

        public void Initialize()
        {
            SetLevel(_levels.FirstOrDefault());
        }

        public bool IsHaveLoadedLevel(out LevelConfig level)
        {
            level = _currentLevel;
            return level != null;
        }

        public void SetLevel(LevelConfig levelConfig)
        {
            if (levelConfig != null)
            {
                var oldLevel = _currentLevel;
                _currentLevel = levelConfig;

                OnLevelChanged?.Invoke(new LevelChangeEventArgs()
                {
                    LevelSystem = this,
                    OldLevel = oldLevel,
                    NewLevel = _currentLevel
                });
            }
        }
    }
}