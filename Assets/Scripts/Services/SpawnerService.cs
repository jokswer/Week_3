using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Services
{
    public class SpawnerService : Service
    {
        [SerializeField] private Transform _playerStartPoint;
        [SerializeField] private Transform _leftBorder;
        [SerializeField] private Transform _rightBorder;
        [SerializeField] private Transform _topBorder;
        [SerializeField] private Transform _bottomBorder;

        [SerializeField] private int _coinsCount;
        [SerializeField] private int _bombsCount;
        [SerializeField] private int _maxRocketsCount = 3;

        [SerializeField] private GameObject _coinPrefab;
        [SerializeField] private GameObject _bombPrefab;
        [SerializeField] private GameObject _rocketPrefab;

        public override void Init()
        {
            CreateStaticObjects();
        }

        private void Start()
        {
            StartCoroutine(CreateRockets());
        }

        private void CreateStaticObjects()
        {
            var x = _playerStartPoint.position.x;
            var leftLimit = _leftBorder.position.z;
            var rightLimit = _rightBorder.position.z;
            var topLimit = _topBorder.position.y;
            var bottomLimit = _bottomBorder.position.y;

            var distance = Mathf.Abs(leftLimit) + Mathf.Abs(rightLimit);
            var coinsStep = distance / _coinsCount;
            var bombsStep = distance / _bombsCount;

            for (var z = leftLimit; z < rightLimit; z += coinsStep)
            {
                var y = Random.Range(bottomLimit, topLimit);
                Instantiate(_coinPrefab, new Vector3(x, y, z), Quaternion.identity, transform);
            }


            for (var z = leftLimit; z < rightLimit; z += bombsStep)
            {
                var y = Random.Range(bottomLimit, topLimit);
                Instantiate(_bombPrefab, new Vector3(x, y, z), Quaternion.identity, transform);
            }
        }

        private IEnumerator CreateRockets()
        {
            var x = _playerStartPoint.position.x;
            var z = _leftBorder.position.z - 10;
            var y = _topBorder.position.y;

            for (var i = 0; i < _maxRocketsCount; i++)
            {
                Instantiate(_rocketPrefab, new Vector3(x, y, z), Quaternion.identity, transform);

                yield return new WaitForSeconds(5f);
            }
        }
    }
}