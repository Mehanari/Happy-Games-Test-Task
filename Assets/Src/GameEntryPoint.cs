using Src.InputHandling;
using UnityEngine;

namespace Src
{
    public class GameEntryPoint : MonoBehaviour
    {
        [SerializeField] private float ballDefaultSpeed = 10f;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Ball ball;
        [SerializeField] private BallDestinationsController ballDestinationsController;
        [SerializeField] private ClickDetector clickDetector;

        private PlayerControls _controls;

        private void Awake()
        {
            _controls = new PlayerControls();
            _controls.Enable();
        
            //Initializing ball
            ball.Speed = ballDefaultSpeed;
        
            //Initializing click detector
            clickDetector.Init(_controls, mainCamera);
            ballDestinationsController.Init(ball, clickDetector);
        }
    }
}
