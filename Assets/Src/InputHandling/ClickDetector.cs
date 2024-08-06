using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Src.InputHandling
{
    /// <summary>
    /// Tracks current mouse or touch (or any other control that allows screen position selection) position via
    /// ChangePosition action from PlayerControls.Gameplay.
    ///
    /// Invokes Click event each time Click action from PlayerControls.Gameplay is called and passes
    /// touch position converted to the world point via Camera.main.
    /// </summary>
    public class ClickDetector : MonoBehaviour, IClickDetector
    {
        public event Action<Vector2> Click;

        private PlayerControls _playerControls;
        private Camera _camera;
        private Vector2 _currentPosition;

        private void Awake()
        {
            _playerControls = new PlayerControls();
            _camera = Camera.main;
        }

        private void OnEnable()
        {
            _playerControls.Enable();
            _playerControls.Gameplay.ChangePosition.performed += OnPositionChange;
            _playerControls.Gameplay.Click.performed += OnClick;
        }

        
        private void OnDisable()
        {
            _playerControls.Disable();
            _playerControls.Gameplay.ChangePosition.performed -= OnPositionChange;
            _playerControls.Gameplay.Click.performed -= OnClick;
        }

        private void OnPositionChange(InputAction.CallbackContext context)
        {
            _currentPosition = context.ReadValue<Vector2>();
        }

        
        private void OnClick(InputAction.CallbackContext context)
        {
            var worldPosition = _camera.ScreenToWorldPoint(_currentPosition);
            Click?.Invoke(worldPosition);
        }
    }
}