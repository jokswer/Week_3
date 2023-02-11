using Player;
using UnityEngine;

public class CameraTransform : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    private Transform _target;

    private void Start()
    {
        _target = FindObjectOfType<PlayerView>().transform;
    }

    private void LateUpdate()
    {
        transform.position = _target.position + offset;
    }
}