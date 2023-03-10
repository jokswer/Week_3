namespace Player
{
    public class PlayerPresenter
    {
        private PlayerView _playerView;
        private PlayerModel _playerModel;

        public PlayerPresenter(PlayerView playerView, PlayerModel playerModel)
        {
            _playerView = playerView;
            _playerModel = playerModel;
        }

        public void Update()
        {
            var angle = _playerModel.GetAngle();
            _playerView.SetHorizontalRotation(angle);
        }

        public void FixedUpdate()
        {
            _playerView.AddForce(_playerModel.VerticalForce, _playerModel.HorizontalForce);
        }

        public void OnEnable()
        {
            _playerModel.OnEnable();
            _playerView.OnTakeDamage += _playerModel.Health.SetDamage;
        }

        public void OnDisable()
        {
            _playerModel.OnDisable();
            _playerView.OnTakeDamage -= _playerModel.Health.SetDamage;
        }
    }
}