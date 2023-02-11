using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerView : MonoBehaviour
    {
        public Action<int> OnTakeDamage;

        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void TakeDamage(int damage)
        {
            OnTakeDamage?.Invoke(damage);
        }

        public void AddForce(float vertical, float horizontal)
        {
            _rigidbody.AddForce(0, vertical, horizontal);
        }

        public void SetHorizontalRotation(float angle)
        {
            transform.eulerAngles = new Vector3(angle, 0, 0);
        }
    }
}