using System;
using Declarative;
using Lessons.Gameplay.Atomic1;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2
{
    [Serializable]
    public sealed class Life
    {
        [ShowInInspector]
        public AtomicEvent<int> onTakeDamage = new AtomicEvent<int>();

        [SerializeField]
        public AtomicVariable<int> hitPoints = new AtomicVariable<int>();

        [SerializeField]
        public AtomicVariable<bool> isDeath;

        [Construct]
        public void Construct()
        {
            onTakeDamage += damage => this.hitPoints.Value -= damage;
            this.hitPoints.OnChanged += hitPoints =>
            {
                if (hitPoints <= 0) isDeath.Value = true;
            };
        }
    }

}