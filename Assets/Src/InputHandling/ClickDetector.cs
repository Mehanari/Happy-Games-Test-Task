using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Src.InputHandling
{
    public class ClickDetector : MonoBehaviour, IClickDetector
    {
        public event Action<Vector2> Click;

        private PlayerControls _playerControls;
        private Camera _camera;

        public void Init(PlayerControls playerControls, Camera mainCamera)
        {
            _playerControls = playerControls;
            _camera = mainCamera;
        }

        private void OnEnable()
        {
            _playerControls.Gameplay.Tap.performed += OnTap;
        }

        private void OnDisable()
        {
            _playerControls.Gameplay.Tap.performed -= OnTap;
        }

        private void OnTap(InputAction.CallbackContext context)
        {
            var clickScreenPosition = context.ReadValue<Vector2>();
            var worldPosition = _camera.ScreenToWorldPoint(clickScreenPosition);
            Click?.Invoke(worldPosition);
        }
    }
}