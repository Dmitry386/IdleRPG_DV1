using Packages.DVParameters.Source.Mono;
using UnityEngine;

namespace Assets.Scripts.Systems.Helpers
{
    internal class HealthHelperMono : MonoBehaviour
    {
        [SerializeField]
        private FloatDataParameters _parameters;

        public void AddHealth(float val)
        {
            HealthHelper.AddHealth(_parameters, val);
        }
    }
}
