using Lessons.Gameplay.Atomic1;

namespace Lessons.Gameplay.Atomic2
{
    public sealed class ActivateComponent : IActivateComponent
    {
        public AtomicEvent OnActivate;
        public ActivateComponent(AtomicEvent onActivate)
        {
            OnActivate = onActivate;
        }

        public void Activate()
        {
            OnActivate?.Invoke();
        }
    }
}