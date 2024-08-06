using System.Collections.Generic;
using UnityEngine;

namespace Src
{
   /// <summary>
   /// Adds new destination to the queue each time the Click event is invoked
   /// on the given IClickDetector.
   /// Sequentially passes those destinations to the given IMovable, switching
   /// to a new destination each time the Arrived event is invoked.
   /// </summary>
   public class DestinationsQueueController : MonoBehaviour
   {
      private IMovable _movable;
      private IClickDetector _clickDetector;
      private readonly Queue<Vector2> _destinations = new ();

      public void Init(IMovable movable, IClickDetector clickDetector)
      {
         _movable = movable;
         _clickDetector = clickDetector;
      }

      private void OnEnable()
      {
         _movable.Arrived += OnArrived;
         _clickDetector.Click += OnClick;
      }

      private void OnDisable()
      {
         _movable.Arrived -= OnArrived;
         _clickDetector.Click -= OnClick;
      }

      private void OnClick(Vector2 clickPosition)
      {
         _destinations.Enqueue(clickPosition);
         if (_destinations.Count == 1 && !_movable.IsMoving)
         {
            _movable.MoveTo(_destinations.Dequeue());
         }
      }

      private void OnArrived()
      {
         if (_destinations.Count > 0)
         {
            _movable.MoveTo(_destinations.Dequeue());
         }
      }
   }
}
