using TMPro;
using UnityEngine;

namespace Services
{
    public class CoinService : Service
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private GameObject _winMessage;

        private int _coinsCount;
        private int _collectedCoinsCount;
        private CoinView[] _coins;

        public override void Init()
        {
            _winMessage.SetActive(false);

            _coins = FindObjectsOfType<CoinView>();
            _coinsCount = _coins.Length;

            ChangeScoreText();
        }

        private void OnCoinDestroy()
        {
            _collectedCoinsCount++;

            ChangeScoreText();
            CheckWinCondition();
        }

        private void CheckWinCondition()
        {
            if (_coinsCount == _collectedCoinsCount)
            {
                _winMessage.SetActive(true);
            }
        }

        private void ChangeScoreText()
        {
            _scoreText.text = $"Монеты: {_collectedCoinsCount} из {_coinsCount}";
        }

        private void OnEnable()
        {
            foreach (var coin in _coins)
            {
                coin.OnDestroy += OnCoinDestroy;
            }
        }

        private void OnDisable()
        {
            foreach (var coin in _coins)
            {
                coin.OnDestroy -= OnCoinDestroy;
            }
        }
    }
}