using UnityEngine;

namespace Player
{
    public class PlayerHealth
    {
        private float _health;

        public float CurrentHealth => _health;
        public bool IsAlive => _health > 1;

        public PlayerHealth(float maxHealth)
        {
            _health = maxHealth;
        }

        public void SetDamage(int damage = 1)
        {
            _health -= damage;
            Debug.Log(CurrentHealth);
            Debug.Log(IsAlive);
        }
    }
}