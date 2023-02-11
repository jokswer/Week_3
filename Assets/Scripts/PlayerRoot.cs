using Player;
using UnityEngine;

public class PlayerRoot : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;

    [Header("Player Config")] 
    [SerializeField] private Transform _startPoint;
    [SerializeField] private float _force = 5f;
    [SerializeField] private float _maxHealth = 5f;

    private PlayerPresenter _playerPresenter;

    private void Awake()
    {
        var playerObject = Instantiate(_playerPrefab, _startPoint.position, Quaternion.identity);
        var playerView = playerObject.GetComponent<PlayerView>();

        var playerModel = new PlayerModel(_force, _maxHealth);
        _playerPresenter = new PlayerPresenter(playerView, playerModel);
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
    }

    private void OnDisable()
    {
        _playerPresenter.OnDisable();
    }
}