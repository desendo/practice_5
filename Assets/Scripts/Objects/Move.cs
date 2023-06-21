using System;
using Declarative;
using Lessons.Gameplay.Atomic1;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2
{
    [Serializable]
    public sealed class Move
    {
        [SerializeField]
        public Transform moveTransform;

        [ShowInInspector]
        public AtomicEvent<Vector3> onMove = new AtomicEvent<Vector3>();

        [SerializeField]
        public AtomicVariable<bool> moveRequired = new AtomicVariable<bool>();

        [SerializeField]
        public AtomicVariable<Vector3> moveDirection = new AtomicVariable<Vector3>();

        [SerializeField]
        public AtomicVariable<float> speed = new AtomicVariable<float>();

        private readonly FixedUpdateMechanics fixedUpdate = new FixedUpdateMechanics();

        [Construct]
        public void Construct(Life life)
        {
            var isDeath = life.isDeath;
            onMove += direction =>
            {
                if (isDeath.Value)
                {
                    return;
                }

                moveDirection.Value = direction;
                moveRequired.Value = true;
            };

            fixedUpdate.Do(deltaTime =>
            {
                if (moveRequired.Value)
                {
                    moveTransform.position += moveDirection.Value * (speed.Value * deltaTime);
                    moveRequired.Value = false;
                }
            });
        }
    }
}