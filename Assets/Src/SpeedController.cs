using UnityEngine;
using UnityEngine.UI;

namespace Src
{
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
