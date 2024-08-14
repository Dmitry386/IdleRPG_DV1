using Assets.Scripts.Systems.BattleMode;
using Assets.Scripts.Systems.Helpers;
using Packages.DVParameters.Source.Mono;
using Packages.DVParameters.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Systems.DeathSystems
{
    internal class DeathBlockScreen:MonoBehaviour
    {
        [SerializeField]
        private FloatDataParameters _character;

        [SerializeField]
        private GameObject _screenBlocker;

        [SerializeField]
        [Min(0)]
        private float _waitTime = 10f;

        private void Awake()
        {
            _character.DataContainer.OnChanged += DataContainer_OnChanged;
            _screenBlocker.SetActive(false);
        }

        private void DataContainer_OnChanged(DataParameterContainer<float> obj)
        {
            if (HealthHelper.IsDeath(_character))
            {
                OnDeath();
            }
        }

        private void OnDeath()
        {  
            StopAllCoroutines();
            StartCoroutine(Blocking());
        }

        private IEnumerator Blocking()
        {
            yield return null; 
            HealthHelper.AddHealth(_character, int.MaxValue);
            _screenBlocker.SetActive(true);
            yield return new WaitForSeconds(_waitTime);
            _screenBlocker.SetActive(false);
        }

        private void OnDestroy()
        {
            _character.DataContainer.OnChanged -= DataContainer_OnChanged;
        }
    }
}
