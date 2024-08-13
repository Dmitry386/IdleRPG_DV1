using Assets.Scripts.Configs.WorldConfig;
using Assets.Scripts.Systems.LevelSystems;
using DVUnityUtilities;
using DVUnityUtilities.Other.ServiceLocator;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.UI.LevelSwitching
{
    internal class LevelSwitchButtonUI : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Image _levelPreview;

        [SerializeField]
        private LevelConfig _level;

        private void Awake()
        {
            _levelPreview.sprite = _level.Background;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            var levelSystem = DVServiceLocator.GetService<LevelSystem>();

            if (levelSystem)
            {
                levelSystem.SetLevel(_level);
            }
        }

        private void OnValidate()
        {
            Util.ValidateComponentOrGet(gameObject, ref _levelPreview);
        }
    }
}