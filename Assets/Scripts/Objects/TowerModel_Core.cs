using Declarative;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2
{
    public class TowerModel_Core
    {
        [SerializeField]
        [Section]
        public Life life = new Life();

        [SerializeField]
        [Section]
        public TowerAttack attack = new TowerAttack();
    }
}