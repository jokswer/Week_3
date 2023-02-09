using Player;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RocketMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PlayerView _target;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _target = FindObjectOfType<PlayerView>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var relativePos = _target.transform.position - transform.position;
        var rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        _rigidbody.rotation = rotation;

        _rigidbody.velocity = transform.forward * _speed;
    }
}