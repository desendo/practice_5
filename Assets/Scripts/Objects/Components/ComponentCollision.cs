using System;
using Lessons.Gameplay.Atomic1;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2
{
    public class ComponentCollision : IComponent_Collision
    {

        public Entity Entity;
        public event Action<Entity, Collision> OnEventWithCollision;
        public ComponentCollision(Entity entity, AtomicEvent<Collision> onCollisionEntered)
        {
            Entity = entity;
            onCollisionEntered += x => OnEventWithCollision?.Invoke(entity, x);
        }
    }
}