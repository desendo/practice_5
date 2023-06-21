using Lessons.Gameplay.Atomic1;

namespace Lessons.Gameplay.Atomic2
{
    public interface IDamageComponent
    {
        public AtomicVariable<int> Damage { get; }

    }
}