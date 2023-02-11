using Services;
using UnityEngine;

public class ServicesRoot : MonoBehaviour
{
    [SerializeField] private SpawnerService _spawnerService;
    [SerializeField] private CoinService _coinService;
    [SerializeField] private HealthService _healthService;

    private void Awake()
    {
        _spawnerService.Init();
        _coinService.Init();
        _healthService.Init();
    }
}