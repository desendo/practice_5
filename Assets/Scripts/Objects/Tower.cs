using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2
{
    public sealed class Tower : MonoBehaviour
    {
        [SerializeField]
        private int hitPoints;

        [Header("Range Attack")]
        [SerializeField]
        private float rangeDistance;

        [SerializeField]
        private Transform firePoint;

        [Button]
        public void TakeDamage(int damage)
        {
            hitPoints -= damage;
            if (hitPoints <= 0)
            {
                Destroy(gameObject);
            }
        }

        [Button]
        public void Attack(GameObject target)
        {
            var distanceVector = target.transform.position - transform.position;
            if (distanceVector.magnitude > rangeDistance)
            {
                return;
            }

            var direction = distanceVector.normalized;
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            BulletManager.Instance.LaunchBullet(firePoint.position, direction);
        }
    }
}