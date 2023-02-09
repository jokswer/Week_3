using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 150;

    private void Update()
    {
        transform.Rotate(Vector3.up * (Time.deltaTime * _rotationSpeed));
    }
}