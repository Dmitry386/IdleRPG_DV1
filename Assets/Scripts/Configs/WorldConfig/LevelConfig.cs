using UnityEngine;

namespace Assets.Scripts.Configs.WorldConfig
{
    [CreateAssetMenu(fileName = "LevelCFG", menuName = "ScriptableObjects/Cfg/LevelCFG")]
    internal class LevelConfig : ScriptableObject
    {
        public string Name;

        public Sprite Background;
         
        public CharacterListConfig Enemies;
    }
}