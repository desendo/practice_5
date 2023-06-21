using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Gameplay.Atomic1
{
    [Serializable]
    public class AtomicVariable<T> : IAtomicVariable<T>
    {
        public AtomicEvent<T> OnChanged { get; set; }

        public T Value
        {
            get { return value; }
            set
            {
                this.value = value;
                OnChanged?.Invoke(value);
            }
        }

        [OnValueChanged("OnValueChanged")]
        [SerializeField]
        private T value;

#if UNITY_EDITOR
        private void OnValueChanged(T value)
        {
            OnChanged?.Invoke(value);
        }
#endif
    }
}