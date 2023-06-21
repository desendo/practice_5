using Lessons.Gameplay.Atomic1;

namespace Lessons.Gameplay.Atomic2
{
    public class ComponentTakeDamage : IComponent_TakeDamage
    {
        private  AtomicEvent<int> onTakeDamage;

        public ComponentTakeDamage(AtomicEvent<int> onTakeDamage)
        {
            this.onTakeDamage = onTakeDamage;
        }

        public void TakeDamage(int damage)
        {
            onTakeDamage.Invoke(damage);
        }
    }
}