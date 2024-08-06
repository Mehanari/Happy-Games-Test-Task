using UnityEngine;
using UnityEngine.UI;

namespace Src
{
   /// <summary>
   /// Reacts to the slider value changes and adjusts
   /// speed of the given IMovable accordingly.
   /// Sets speed according to formula: slider_value * max_speed,
   /// where max speed is taken from config.
   ///
   /// In the Init method sets speed of the given IMovable to default value from config.
   /// </summary>
   public class SpeedController : MonoBehaviour
   {
      private Slider _slider;
      private SpeedConfig _speedConfig;
      private IMovable _movable;

      public void Init(Slider slider, SpeedConfig speedConfig, IMovable movable)
      {
         _slider = slider;
         _speedConfig = speedConfig;
         _movable = movable;
         _slider.SetValueWithoutNotify(_speedConfig.DefaultSpeed/_speedConfig.MaxSpeed);
         _movable.Speed = _speedConfig.DefaultSpeed;
      }

      private void OnEnable()
      {
         _slider.onValueChanged.AddListener(OnValueChanged);
      }

      private void OnDisable()
      {
         _slider.onValueChanged.RemoveListener(OnValueChanged);
      }

      private void OnValueChanged(float value)
      {
         _movable.Speed = _speedConfig.MaxSpeed * value;
      }
   }
}
