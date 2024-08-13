using UnityEngine;

namespace Assets.Scripts.Systems.BattleMode.Helpers
{
    internal class EnableIfBattleMode : MonoBehaviour
    {
        [SerializeField]
        private bool _inverse = false;

        [SerializeField]
        private BattleModeSystem _battleModeSystem;

        [SerializeField]
        private GameObject _controlObj;

        private void Awake()
        {
            _battleModeSystem.OnChanged.AddListener(OnChanged);
            UpdateBlock();
        }

        private void OnChanged(BattleModeSystem arg0)
        {
            UpdateBlock();
        }

        private void UpdateBlock()
        {
            if (!_inverse)
            {
                _controlObj.SetActive(_battleModeSystem.IsActiveBattleMode());
            }
            else
            {
                _controlObj.SetActive(!_battleModeSystem.IsActiveBattleMode());
            }
        }
    }
}