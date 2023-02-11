using Player;
using Services;
using UnityEngine;

public class PlayerRoot : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private HealthService _healthService;

    [Header("Player Config")] [SerializeField]
    private Transform _startPoint;

    [SerializeField] private float _force = 5f;
    [SerializeField] private int _maxHealth = 5;

    private PlayerPresenter _playerPresenter;
    private PlayerModel _playerModel;

    private void Awake()
    {
        var playerObject = Instantiate(_playerPrefab, _startPoint.position, Quaternion.identity);
        var playerView = playerObject.GetComponent<PlayerView>();

        _playerModel = new PlayerModel(_force, _maxHealth);
        _playerPresenter = new PlayerPresenter(playerView, _playerModel);

        _healthService.ChangeHealthText(_maxHealth);
    }

    private void Update()
    {
        _playerPresenter.Update();
    }

    private void FixedUpdate()
    {
        _playerPresenter.FixedUpdate();
    }

    private void OnEnable()
    {
        _playerPresenter.OnEnable();
        _playerModel.Health.OnHealthChange += _healthService.ChangeHealthText;
    }

    private void OnDisable()
    {
        _playerPresenter.OnDisable();
        _playerModel.Health.OnHealthChange -= _healthService.ChangeHealthText;
    }
}