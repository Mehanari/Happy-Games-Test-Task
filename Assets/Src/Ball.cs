using System;
using UnityEngine;

namespace Src
{
    public class Ball : MonoBehaviour, IBall
    {
        public float Speed { get; set; }
        public bool IsMoving { get; private set; }
    
        public event Action Arrived;
    
        private Vector2 _targetPosition;
    
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
