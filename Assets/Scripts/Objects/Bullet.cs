using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, Collision> OnCollisionEntered;
        public event Action<Bullet> OnLifetimeFinished;

        public int Damage
        {
            get { return damage; }
        }

        [SerializeField]
        private float speed = 5;

        [SerializeField]
        private int damage = 1;

        [SerializeField]
        private float lifetime = 3;

        public void Move(Vector3 direction)
        {
            StartCoroutine(MoveRoutine(direction));
        }

        private IEnumerator MoveRoutine(Vector3 direction)
        {
            while (true)
            {
                transform.position += direction * speed * Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }
        }

        public void Activate()
        {
            StartCoroutine(ActivateRoutine());
        }

        private IEnumerator ActivateRoutine()
        {
            yield return new WaitForSeconds(lifetime);
            OnLifetimeFinished?.Invoke(this);   
        }

        private void OnCollisionEnter(Collision collision)
        {
            OnCollisionEntered?.Invoke(this, collision);
        }
    }
}