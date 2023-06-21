using System;
using Declarative;
using Lessons.Gameplay.Atomic1;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2
{
    [Serializable]
    public class TowerAttack
    {
        public AtomicValue<float> rangeDistance;
        [SerializeField]
        private Transform firePoint;


        public AtomicEvent<Entity> onAttack;
        private Transform _transform;


        [Construct]
        public void Construct(Transform transform)
        {
            _transform = transform;
            onAttack += Attack;
        }


        private void Attack(Entity target)
        {
            var distanceVector = target.transform.position - this._transform.position;
            if (distanceVector.magnitude > this.rangeDistance.Value)
            {
                return;
            }

            var direction = distanceVector.normalized;
            this._transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            BulletManager.Instance.LaunchBullet(this.firePoint.position, direction);
        }
    }
}