using System;
using Lessons.Gameplay.Atomic1;

namespace Lessons.Gameplay.Atomic2
{
    public interface IFinishComponent
    {
        event Action<Entity> OnFinish;
    }

    public sealed class FinishComponent : IFinishComponent
    {
        public event Action<Entity> OnFinish;

        public FinishComponent(Entity entity, AtomicEvent onFinish)
        {

            onFinish += () => OnFinish?.Invoke(entity);
        }

    }
}