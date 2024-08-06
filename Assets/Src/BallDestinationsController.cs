using System.Collections.Generic;
using UnityEngine;

namespace Src
{
   public class BallDestinationsController : MonoBehaviour
   {
      private IBall _ball;
      private IClickDetector _clickDetector;
      private readonly Queue<Vector2> _destinations = new Queue<Vector2>();

      public void Init(IBall ball, IClickDetector clickDetector)
      {
         _ball = ball;
         _clickDetector = clickDetector;
      }

      private void OnEnable()
      {
         _ball.Arrived += OnArrived;
         _clickDetector.Click += OnClick;
      }

      private void OnDisable()
      {
         _ball.Arrived -= OnArrived;
         _clickDetector.Click -= OnClick;
      }

      private void OnClick(Vector2 clickPosition)
      {
         _destinations.Enqueue(clickPosition);
         if (_destinations.Count == 1 && !_ball.IsMoving)
         {
            _ball.MoveTo(_destinations.Dequeue());
         }
      }

      private void OnArrived()
      {
         if (_destinations.Count > 0)
         {
            _ball.MoveTo(_destinations.Dequeue());
         }
      }
   }
}
