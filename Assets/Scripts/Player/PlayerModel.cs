using UnityEngine;

namespace Player
{
    public class PlayerModel
    {
        private const float MaxAngle = 10f;
        private const float RotationLerpRate = 10f;

        private PlayerInput _playerInput;
        private PlayerHealth _playerHealth;
        private float _force;
        private float _angle;

        public float HorizontalForce => _playerInput.Move.x * _force;
        public float VerticalForce => _playerInput.Move.y * _force;
        public PlayerHealth Health => _playerHealth;

        public PlayerModel(float force, int maxHealth)
        {
            _playerInput = new PlayerInput();
            _playerHealth = new PlayerHealth(maxHealth);
            _force = force;
        }

        public void OnEnable()
        {
            _playerInput.Enable();
        }

        public void OnDisable()
        {
            _playerInput.Disable();
        }

        public float GetAngle()
        {
            var targetAngel = _playerInput.Move.x * MaxAngle;

            _angle = Mathf.Lerp(_angle, targetAngel, RotationLerpRate * Time.deltaTime);

            return _angle;
        }
    }
}