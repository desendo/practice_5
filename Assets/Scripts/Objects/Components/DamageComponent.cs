using Lessons.Gameplay.Atomic1;

namespace Lessons.Gameplay.Atomic2
{
    public class DamageComponent : IDamageComponent
    {
        public AtomicVariable<int> Damage { get; }
        public DamageComponent(AtomicVariable<int> damage)
        {
            Damage = damage;
        }
    }
}