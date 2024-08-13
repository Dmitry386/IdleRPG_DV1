using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Systems.BattleMode
{
    internal class BattleModeSystem : MonoBehaviour
    {
        [SerializeField]
        public UnityEvent<BattleModeSystem> OnChanged;

        private bool _activeBattleMode;

        public bool IsActiveBattleMode()
        {
            return _activeBattleMode;
        }

        public void SetBattleMode(bool isActive)
        {
            _activeBattleMode = isActive;
            Debug.Log($"Battle mode: {_activeBattleMode}");

            OnChanged?.Invoke(this);
        }

        public void SwitchBattleMode()
        {
            SetBattleMode(!IsActiveBattleMode());
        }
    }
}