using System;
using UnityEngine;

public class CoinView : MonoBehaviour
{
    public event Action OnDestroy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyObject();
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
        OnDestroy?.Invoke();
    }
}