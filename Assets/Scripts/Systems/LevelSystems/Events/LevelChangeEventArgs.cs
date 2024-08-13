using Assets.Scripts.Configs.WorldConfig;
using System;

namespace Assets.Scripts.Systems.LevelSystems.Events
{
    internal class LevelChangeEventArgs : EventArgs
    {
        public LevelSystem LevelSystem;
        public LevelConfig OldLevel;
        public LevelConfig NewLevel;
    }
}