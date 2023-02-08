using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerView : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
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