using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2
{
    public sealed class BulletManager : MonoBehaviour
    {
        public static BulletManager Instance;

        [SerializeField]
        private Entity bulletPrefab;

        private void Awake()
        {
            Instance = this;
        }

        [ShowInInspector]
        public void LaunchTest()
        {
            LaunchBullet(transform.position, transform.forward);
        }

        public void LaunchBullet(Vector3 position, Vector3 direction)
        {
            var bullet = Instantiate(bulletPrefab, position, Quaternion.identity, null);

            bullet.Get<ComponentCollision>().OnEventWithCollision += OnCollisionEntered;
            bullet.Get<FinishComponent>().OnFinish += OnLifetimeFinished;
            bullet.Get<MoveComponent>().Move(direction);
            bullet.Get<ActivateComponent>().Activate();
        }

        private void OnCollisionEntered(Entity entity, Collision collision)
        {
            var damage =  entity.Get<DamageComponent>();
            var otherEntity = collision.gameObject.GetComponent<Entity>();

            if (otherEntity != null)
            {
                var otherTakeDamage = otherEntity.Get<ComponentTakeDamage>();
                otherTakeDamage.TakeDamage(damage.Damage.Value);
            }

            DestroyBullet(entity);
        }

        private void OnLifetimeFinished(Entity bullet)
        {
            DestroyBullet(bullet);
        }

        private void DestroyBullet(Entity bullet)
        {
            bullet.Get<ComponentCollision>().OnEventWithCollision -= OnCollisionEntered;
            bullet.Get<FinishComponent>().OnFinish -= OnLifetimeFinished;
            Destroy(bullet.gameObject);
        }
    }
}