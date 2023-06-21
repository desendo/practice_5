using Lessons.Gameplay.Atomic1;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2
{
    public class CollisionSensor : MonoBehaviour
    {
        public AtomicEvent<Collision> Collision;
        private void OnCollisionEnter(Collision other)
        {
            Collision?.Invoke(other);
        }
    }
}