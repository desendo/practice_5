using System;
using Declarative;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2
{
    [Serializable]
    public sealed class WarriorModel_Visual
    {
        private static readonly int State = Animator.StringToHash("State");
        private const int IDLE_STATE = 0;
        private const int MOVE_STATE = 1;
        private const int DEATH_STATE = 5;

        [SerializeField]
        public Animator animator;

        [SerializeField]
        public Transform visualTransform;

        private readonly LateUpdateMechanics lateUpdate = new LateUpdateMechanics();

        [Construct]
        public void Construct(WarriorModel_Core core)
        {
            var isDeath = core.Life.isDeath;
            var moveRequired = core.Move.moveRequired;
            var moveDirection = core.Move.moveDirection;

            lateUpdate.SetAction(_ =>
            {
                if (isDeath.Value)
                {
                    animator.SetInteger(State, DEATH_STATE);
                    return;
                }

                if (moveRequired.Value)
                {
                    animator.SetInteger(State, MOVE_STATE);
                    visualTransform.rotation = Quaternion.LookRotation(moveDirection.Value);
                }
                else
                {
                    animator.SetInteger(State, IDLE_STATE);
                }
            });
        }

    }
}