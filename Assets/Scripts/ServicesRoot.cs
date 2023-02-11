using Services;
using UnityEngine;

public class ServicesRoot : MonoBehaviour
{
        [SerializeField] private SpawnerService _spawnerService;
        [SerializeField] private CoinService _coinService;

        private void Awake()
        {
                _spawnerService.Init();
                _coinService.Init();
        }
}