using Assets.Scripts.Entities.Enemy;
using Assets.Scripts.Entities.Items.Weapons;
using Assets.Scripts.Systems.AttackSystems.Events;
using Assets.Scripts.Systems.Helpers;
using DVUnityUtilities;
using DVUnityUtilities.Other.Coroutines;
using DVUnityUtilities.Other.Pools;
using Packages.DVParameters.Source.Mono;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Systems.AttackSystems
{
    internal class IntervalDamager : MonoBehaviour
    {
        [SerializeField]
        private CharacterEntity _owner;

        [SerializeField]
        private CharacterEntity _target;

        [SerializeField]
        private bool _autoSearchTarget = true;

        [SerializeField]
        [Min(0)]
        private float _autoSearchInterval = 0.15f;

        [SerializeField]
        public UnityEvent<IntervalDamagerStateChangeEventArgs> OnAttackStateChanged;

        private IntervalDamagerState _state = IntervalDamagerState.None;

        private void OnEnable()
        {
            if (_autoSearchTarget)
            {
                new CoroutineTimer(this, _autoSearchInterval, true).Start().OnTick += OnSearching;
            }
        }

        private void OnSearching(CoroutineTimer obj)
        {
            if (_target) return;

            var allCharacters = WCache.GetAll<CharacterEntity>();
            foreach (var character in allCharacters)
            {
                if (character != _owner)
                {
                    OnEnemyFounded(character);
                    break;
                }
            }
        }

        private void OnEnemyFounded(CharacterEntity character)
        {
            _target = character;
        }

        private void Update()
        {
            if (_target)
            {
                if (_owner.IsHaveWeapon(out var weapon))
                {
                    if (_state == IntervalDamagerState.None)
                    {
                        StartCoroutine(AttackProcessing(weapon));
                    }
                }
            }
        }

        private IEnumerator AttackProcessing(WeaponEntity weapon)
        {
            float actionDuration;

            actionDuration = _owner.Config.DurationPrepareToAttack;
            SetDamageState(IntervalDamagerState.Preparing, actionDuration);
            yield return new WaitForSeconds(actionDuration);

            actionDuration = weapon.Config.DurationOfAttack;
            SetDamageState(IntervalDamagerState.Attacking, actionDuration);
            yield return new WaitForSeconds(actionDuration);

            DowngradeHealth(_target, CalculateDamage(_target, weapon));
            SetDamageState(IntervalDamagerState.None, 0);
        }

        public void SetDamageState(IntervalDamagerState state, float actionDuration)
        {
            _state = state;
            DebugUtils.Log(this, $"{name} attack state: {_state}");

            OnAttackStateChanged.Invoke(new IntervalDamagerStateChangeEventArgs()
            {
                Damager = this,
                NewState = state,
                StateDuration = actionDuration
            });
        }

        public IntervalDamagerState GetDamageState()
        {
            return _state;
        }

        public void StopAttackProcessing()
        {
            StopAllCoroutines();
            SetDamageState(IntervalDamagerState.None, 0);
        }

        private static float CalculateDamage(CharacterEntity target, WeaponEntity weapon)
        {
            if (target && target.TryGetComponent<FloatDataParameters>(out var parameters))
            {
                if (parameters.DataContainer.GetData("Armour", out var armourParam))
                {
                    return HealthHelper.GetDamage(weapon.Config.Damage, armourParam.Value);
                }
            }

            return weapon.Config.Damage;
        }

        private static void DowngradeHealth(CharacterEntity target, float damage)
        {
            if (target && target.TryGetComponent<FloatDataParameters>(out var parameters))
            {
                HealthHelper.DowngradeHealth(parameters, damage);
            }
        }

        private void OnValidate()
        {
            Util.ValidateComponentOrGet(gameObject, ref _owner);
        }
    }
}