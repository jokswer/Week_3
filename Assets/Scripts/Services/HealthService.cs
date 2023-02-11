using TMPro;
using UnityEngine;

namespace Services
{
    public class HealthService : Service
    {
        [SerializeField] private TextMeshProUGUI _healthCount;
        [SerializeField] private GameObject _deathMessage;

        public override void Init()
        {
            _deathMessage.SetActive(false);
        }

        public void ChangeHealthText(int health)
        {
            if (health < 1)
            {
                _deathMessage.SetActive(true);
                _healthCount.text = $"Очки здоровья: 0";
                return;
            }

            _healthCount.text = $"Очки здоровья: {health}";
        }
    }
}