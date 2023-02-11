using UnityEngine;

namespace Player
{
    public class PlayerModel
    {
        private const float MaxAngle = 10f;
        
        private PlayerInput _playerInput;
        private PlayerHealth _playerHealth;
        private float _force;
        private float _angle;

        public float HorizontalForce => _playerInput.Move.x * _force;
        public float VerticalForce => _playerInput.Move.y * _force;
        public PlayerHealth Health => _playerHealth;

        public PlayerModel(float force, float maxHealth)
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
            if (_playerInput.Move.x != 0)
            {
                _angle += _playerInput.Move.x;
            }
            else
            {
                _angle += _angle > 0 ? -0.5f : 0.5f;
            }

            _angle = Mathf.Clamp(_angle, -MaxAngle, MaxAngle);

            return _angle;
        }
    }
}