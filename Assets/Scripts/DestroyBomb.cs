using UnityEngine;

public class DestroyBomb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Bomb"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}