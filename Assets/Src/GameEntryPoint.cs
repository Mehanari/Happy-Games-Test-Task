using Src.InputHandling;
using UnityEngine;
using UnityEngine.UI;

namespace Src
{
    /// <summary>
    /// Entry point of the game used to manage primary classes dependencies in one place.
    /// </summary>
    public class GameEntryPoint : MonoBehaviour
    {
        [SerializeField] private Ball ball;
        [Header("Ball destinations settings")]
        [SerializeField] private DestinationsQueueController destinationsQueueController;
        [SerializeField] private ClickDetector clickDetector;
        [Header("Ball speed settings")]
        [SerializeField] private SpeedController speedController;
        [SerializeField] private SpeedConfig speedConfig;
        [SerializeField] private Slider speedSlider;
        

        private void Awake()
        {
            destinationsQueueController.Init(ball, clickDetector);
            speedController.Init(speedSlider, speedConfig, ball);
        }
    }
}
