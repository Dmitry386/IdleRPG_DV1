using Assets.Scripts.Entities.Enemy;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Configs.WorldConfig
{
    [CreateAssetMenu(fileName = "CharacterListCFG", menuName = "ScriptableObjects/Cfg/CharacterListCFG")]
    internal class CharacterListConfig : ScriptableObject
    {
        public List<CharacterEntity> CharacterPrefabs = new(); 
    }
}