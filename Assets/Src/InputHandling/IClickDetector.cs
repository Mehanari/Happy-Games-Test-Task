using System;
using UnityEngine;

namespace Src
{
    public interface IClickDetector
    {
        /// <summary>
        /// Invoked when a click is detected.
        /// Passes the position of the click.
        /// </summary>
        public event Action<Vector2> Click;
    }
}