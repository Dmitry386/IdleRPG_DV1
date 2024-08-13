using Assets.Scripts.Systems.LevelSystems.Events;
using UnityEngine;

namespace Assets.Scripts.Systems.LevelSystems
{
    internal class LevelBackgroundChanger : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteBackground;

        [SerializeField]
        private LevelSystem _levelSystem;

        private void Awake()
        {
            _levelSystem.OnLevelChanged.AddListener(OnLevelChanged);
        }

        private void OnLevelChanged(LevelChangeEventArgs levelChangeEvent)
        {
            _spriteBackground.sprite = levelChangeEvent.NewLevel.Background;
        }

        private void OnDestroy()
        {
            _levelSystem.OnLevelChanged.RemoveListener(OnLevelChanged);
        }
    }
}