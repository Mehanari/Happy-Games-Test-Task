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

        private void Awake()
        {
            _playerControls = new PlayerControls();
            _camera = Camera.main;
        }

        private void OnEnable()
        {
            _playerControls.Enable();
            _playerControls.Gameplay.Tap.performed += OnTap;
        }

        private void OnDisable()
        {
            _playerControls.Disable();
            _playerControls.Gameplay.Tap.performed -= OnTap;
        }

        private void OnTap(InputAction.CallbackContext context)
        {
            var clickScreenPosition = Mouse.current.position.value;
            var worldPosition = _camera.ScreenToWorldPoint(clickScreenPosition);
            Click?.Invoke(worldPosition);
        }
    }
}