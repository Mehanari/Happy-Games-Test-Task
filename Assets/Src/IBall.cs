﻿using System;
using UnityEngine;

namespace Src
{
    public interface IBall
    {
        public float Speed { get; set; }
        public bool IsMoving { get; }
        
        public event Action Arrived;
        
        public void MoveTo(Vector2 position);
    }
}