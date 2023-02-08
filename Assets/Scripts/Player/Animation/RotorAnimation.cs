using UnityEngine;

namespace Player.Animation
{
    enum Axes
    {
        Horizontal,
        Vertical
    }

    public class RotorAnimation : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Axes _axis = Axes.Horizontal;

        private void Update()
        {
            var axis = _axis == Axes.Horizontal ? Vector3.up : Vector3.right;
            transform.Rotate(axis, _speed * Time.deltaTime);
        }
    }
}