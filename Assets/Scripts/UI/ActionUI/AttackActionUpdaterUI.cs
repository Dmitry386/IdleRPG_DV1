using Assets.Scripts.Systems.AttackSystems;
using Assets.Scripts.Systems.AttackSystems.Events;
using UnityEngine;

namespace Assets.Scripts.UI.ActionUI
{
    internal class AttackActionUpdaterUI : MonoBehaviour
    {
        [SerializeField]
        private ProgressBarActionUI _progressBarActionUI;

        [SerializeField]
        private IntervalDamager _damager;

        private void Awake()
        {
            _damager.OnAttackStateChanged.AddListener(OnAttackStateChanged);
        }

        private void OnAttackStateChanged(IntervalDamagerStateChangeEventArgs args)
        {
            _progressBarActionUI.AnimateDowngradeProcess(args.StateDuration);
        }
    }
}