using System;
using Declarative;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2
{
    public sealed class WarriorModel : DeclarativeModel
    {
        [Section]
        [SerializeField]
        public WarriorModel_Core WarriorModel_Core;
        [Section]
        [SerializeField]
        public WarriorModel_Visual WarriorModel_Visual;
    }
}