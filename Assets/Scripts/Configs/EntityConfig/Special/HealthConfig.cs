using System;
using UnityEngine;

namespace Assets.Scripts.Configs.EntityConfig.Special
{
    [Serializable]
    internal class HealthConfig
    {
        [Min(0)] 
        public float MaxHealth = 100f; 

        [Min(0)] 
        public float MaxArmour = 100f;
    }
}