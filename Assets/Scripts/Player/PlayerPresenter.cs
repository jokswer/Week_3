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
            _playerView.AddForce(_playerModel.VerticalSpeed, _playerModel.HorizontalSpeed);
        }

        public void OnEnable()
        {
            _playerModel.OnEnable();
        }

        public void OnDisable()
        {
            _playerModel.OnDisable();
        }
    }
}