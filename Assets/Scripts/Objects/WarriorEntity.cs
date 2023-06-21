using UnityEngine;

namespace Lessons.Gameplay.Atomic2
{
    public class WarriorEntity : Entity
    {
        [SerializeField]
        public WarriorModel WarriorModel;
        private void Awake()
        {
            Add(new ComponentTakeDamage(WarriorModel.WarriorModel_Core.Life.onTakeDamage));
        }
    }
}