using Lessons.Gameplay.Atomic1;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2
{
    public interface IMoveComponent
    {
        void Move(Vector3 direction);
    }
    public sealed class MoveComponent : IMoveComponent
    {
        private readonly IAction<Vector3> onMove;

        public MoveComponent(IAction<Vector3> onMove)
        {
            this.onMove = onMove;
        }
        public void Move(Vector3 direction)
        {
            onMove.Invoke(direction);
        }
    }

}