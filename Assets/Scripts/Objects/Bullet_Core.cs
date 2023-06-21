using System;
using System.Collections;
using Declarative;
using Lessons.Gameplay.Atomic1;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2
{
    [Serializable]
    public class Bullet_Core : DeclarativeModel
    {
        [SerializeField]
        public AtomicVariable<float> speed = new AtomicVariable<float>(); //5

        [SerializeField]
        public AtomicVariable<int> damage = new AtomicVariable<int>(); //1

        [SerializeField]
        public AtomicVariable<float> lifetime = new AtomicVariable<float>(); //3

        public AtomicEvent OnActivate = new AtomicEvent();

        public AtomicEvent<Collision> OnCollisionEntered = new AtomicEvent<Collision>();
        public AtomicEvent OnLifetimeFinished = new AtomicEvent();

        public AtomicEvent<Vector3> OnMove = new AtomicEvent<Vector3>();


        private IEnumerator MoveRoutine(Vector3 direction)
        {
            while (true)
            {
                transform.position += direction * speed.Value * Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }
        }

        private IEnumerator ActivateRoutine()
        {
            yield return new WaitForSeconds(lifetime.Value);
            OnLifetimeFinished.Invoke();
        }


        [Construct]
        public void Construct()
        {
            GetComponent<CollisionSensor>().Collision += OnCollisionEntered;
            OnMove += direction => StartCoroutine(MoveRoutine(direction));
            OnActivate += () =>
            {
                StartCoroutine(ActivateRoutine());
            };
        }
    }
}