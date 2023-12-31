﻿using System;
using Declarative;

namespace Lessons.Gameplay.Atomic2
{
    public sealed class LateUpdateMechanics : ILateUpdateListener
    {
        private Action<float> action;
        
        public void SetAction(Action<float> action)
        {
            this.action = action;
        }
        
        void ILateUpdateListener.LateUpdate(float deltaTime)
        {
            action?.Invoke(deltaTime);
        }
    }
}