using Assets.Scripts.Configs.EntityConfig.Special;
using UnityEngine;

namespace Assets.Scripts.Configs.EntityConfig
{
    [CreateAssetMenu(fileName = "CharacterCFG", menuName = "ScriptableObjects/Cfg/CharacterCFG")]
    internal class CharacterConfig : ScriptableObject
    {
        public HealthConfig HealthConfig = new();

        [Tooltip("In seconds")]
        public float DurationPrepareToAttack = 2f;
    }
}