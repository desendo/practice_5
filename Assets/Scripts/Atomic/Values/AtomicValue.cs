using System;
using Sirenix.OdinInspector;

namespace Lessons.Gameplay.Atomic1
{
    public sealed class AtomicValue<T> : IAtomicValue<T>
    {
        [ShowInInspector, ReadOnly]
        public T Value
        {
            get { return func.Invoke(); }
        }

        private readonly Func<T> func;

        public AtomicValue(Func<T> func)
        {
            this.func = func;
        }
    }
}