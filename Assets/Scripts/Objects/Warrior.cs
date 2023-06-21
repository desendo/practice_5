using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2
{
    public sealed class Warrior : MonoBehaviour
    {

        [Header("Hit Points")]
        [SerializeField]
        private int hitPoints;

        [Header("Move")]
        [SerializeField]
        private float speed;

        private bool moveRequired;

        private Vector3 moveDirection;

        [Header("Melee Attack")]
        [SerializeField]
        private float minMeleeDistance;

        [SerializeField]
        private float attackCountdown;

        [SerializeField]
        private int meleeDamage;

        private Coroutine attackCoroutine;

        private void FixedUpdate()
        {
            if (moveRequired)
            {
                transform.position += moveDirection * (speed * Time.fixedDeltaTime);
                moveRequired = false;
            }
        }

        [Button]
        public void TakeDamage(int damage)
        {
            hitPoints -= damage;
            if (hitPoints <= 0)
            {
                Destroy(gameObject);
            }
        }

        [Button]
        public void Move(Vector3 direction)
        {
            moveRequired = true;
            moveDirection = direction;
        }

        [Button]
        public void Attack(GameObject target)
        {
            if (attackCoroutine != null)
            {
                return;
            }

            if (Vector3.Distance(target.transform.position, transform.position) > minMeleeDistance)
            {
                return;
            }

            if (target.TryGetComponent(out Warrior warrior))
            {
                warrior.TakeDamage(meleeDamage);
                attackCoroutine = StartCoroutine(AttackCountdown());
            }
            else if (target.TryGetComponent(out Tower tower))
            {
                tower.TakeDamage(meleeDamage);
                attackCoroutine = StartCoroutine(AttackCountdown());
            }
        }

        private IEnumerator AttackCountdown()
        {
            yield return new WaitForSeconds(attackCountdown);
            attackCoroutine = null;
        }
    }
}