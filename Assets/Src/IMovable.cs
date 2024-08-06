using System;
using UnityEngine;

namespace Src
{
    /// <summary>
    /// Abstraction over any object that can somehow move with certain speed
    /// and invoke Arrived event once it reached given destination.
    /// </summary>
    public interface IMovable
    {
        public float Speed { get; set; }
        public bool IsMoving { get; }
        
        public event Action Arrived;
        
        public void MoveTo(Vector2 position);
    }
}