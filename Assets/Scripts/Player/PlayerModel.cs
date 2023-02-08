using UnityEngine;

namespace Player
{
    public class PlayerModel
    {
        private const float MaxAngle = 25f;
        private PlayerInput _playerInput;
        private float _speed;
        private float _angle;

        public float HorizontalSpeed => _playerInput.Move.x * _speed;
        public float VerticalSpeed => _playerInput.Move.y * _speed;

        public PlayerModel(float speed)
        {
            _playerInput = new PlayerInput();
            _speed = speed;
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