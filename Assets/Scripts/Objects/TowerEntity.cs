using UnityEngine;

namespace Lessons.Gameplay.Atomic2
{
    public class TowerEntity : Entity
    {
        [SerializeField]
        public TowerModel TowerModel;

        private void Awake()
        {
            Add(new ComponentTakeDamage(TowerModel.core.life.onTakeDamage));
        }
    }
}