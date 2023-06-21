using UnityEngine;

namespace Lessons.Gameplay.Atomic2
{
    public class BulletEntity : Entity
    {
        [SerializeField]
        public Bullet_Core Bullet_Core;

        private void Awake()
        {
            Add(new ComponentCollision(this, Bullet_Core.OnCollisionEntered));
            Add(new MoveComponent(Bullet_Core.OnMove));
            Add(new FinishComponent(this, Bullet_Core.OnLifetimeFinished));
            Add(new ActivateComponent(Bullet_Core.OnActivate));
            Add(new DamageComponent(Bullet_Core.damage));
        }
    }
}