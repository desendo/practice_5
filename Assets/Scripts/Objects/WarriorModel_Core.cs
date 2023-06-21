using System;
using Declarative;
using Lessons.Gameplay.Atomic1;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2
{
    [Serializable]
    public sealed class WarriorModel_Core
    {
        [SerializeField]
        [Section]
        public Life Life;
        [SerializeField]
        [Section]
        public Move Move;
        [SerializeField]
        public AtomicAction<int> Damage;
    }
}