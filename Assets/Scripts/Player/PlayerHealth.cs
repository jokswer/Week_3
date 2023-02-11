using System;

namespace Player
{
    public class PlayerHealth
    {
        private int _health;

        public Action<int> OnHealthChange;

        public PlayerHealth(int maxHealth)
        {
            _health = maxHealth;
        }

        public void SetDamage(int damage = 1)
        {
            _health -= damage;
            OnHealthChange?.Invoke(_health);
        }
    }
}