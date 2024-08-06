using System;
using UnityEngine;

namespace Src
{
    /// <summary>
    /// Script that can move a gameObject, to which it is attached, to a certain position
    /// with given speed.
    /// </summary>
    public class Ball : MonoBehaviour, IMovable
    {
        private Vector2 _targetPosition;

        public float Speed { get; set; }
        public bool IsMoving { get; private set; }
    
        public event Action Arrived;
        
        public void MoveTo(Vector2 position)
        {
            _targetPosition = position;
            IsMoving = true;      
        }

        private void Update()
        {
            if (!IsMoving)
                return;
        
            var currentPosition = transform.position;
        
            if (Vector2.Distance(currentPosition, _targetPosition) < Vector2.kEpsilon)
            {
                IsMoving = false;
                Arrived?.Invoke();
            }
        
            transform.position = Vector2.MoveTowards(currentPosition, _targetPosition, Speed * Time.deltaTime);
        }
    }
}
