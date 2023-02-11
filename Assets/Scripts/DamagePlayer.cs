using Player;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerView>(out var playerView))
        {
            playerView.TakeDamage(_damage);
        }
    }
}