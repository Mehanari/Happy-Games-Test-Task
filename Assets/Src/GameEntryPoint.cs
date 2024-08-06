using Src.InputHandling;
using UnityEngine;
using UnityEngine.UI;

namespace Src
{
    public class GameEntryPoint : MonoBehaviour
    {
        [SerializeField] private Ball ball;
        [Header("Ball destinations")]
        [SerializeField] private DestinationsController destinationsController;
        [SerializeField] private ClickDetector clickDetector;
        [Header("Ball speed")]
        [SerializeField] private SpeedController speedController;
        [SerializeField] private SpeedConfig speedConfig;
        [SerializeField] private Slider speedSlider;
        

        private void Awake()
        {
            destinationsController.Init(ball, clickDetector);
            speedController.Init(speedSlider, speedConfig, ball);
        }
    }
}
