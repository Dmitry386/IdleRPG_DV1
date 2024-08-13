using Assets.Scripts.Systems.BattleMode;
using Assets.Scripts.Systems.Helpers;
using Packages.DVParameters.Source;
using Packages.DVParameters.Source.Mono;
using UnityEngine;

namespace Assets.Scripts.Systems.DeathSystems
{
    internal class StopBattleModeIfDeath : MonoBehaviour
    {
        [SerializeField]
        private FloatDataParameters _character;

        [SerializeField]
        private BattleModeSystem _battleModeSystem;

        private void Awake()
        {
            _character.DataContainer.OnChanged += DataContainer_OnChanged;
        }

        private void DataContainer_OnChanged(DataParameterContainer<float> obj)
        {
            if (HealthHelper.IsDeath(_character))
            {
                _battleModeSystem.SetBattleMode(false);
            }
        }

        private void OnDestroy()
        {
            _character.DataContainer.OnChanged -= DataContainer_OnChanged;
        }
    }
}