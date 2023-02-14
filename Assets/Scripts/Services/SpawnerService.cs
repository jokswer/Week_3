using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Services
{
    public class SpawnerService : Service
    {
        [SerializeField] private Transform _createionZone;

        [SerializeField] private int _coinsCount;
        [SerializeField] private int _bombsCount;
        [SerializeField] private int _maxRocketsCount = 3;

        [SerializeField] private GameObject _coinPrefab;
        [SerializeField] private GameObject _bombPrefab;
        [SerializeField] private GameObject _rocketPrefab;
        
        private const float BorderLimit = 0.5f;
        private const float Distance = 1f;

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
            var coinsStep = Distance / _coinsCount;
            var bombsStep = Distance / _bombsCount;

            for (var z = -BorderLimit; z < BorderLimit; z += coinsStep)
            {
                var position = GetPosition(z);
                Instantiate(_coinPrefab, position, Quaternion.identity, transform);
            }

            for (var z = -BorderLimit; z < BorderLimit; z += bombsStep)
            {
                var position = GetPosition(z);
                Instantiate(_bombPrefab, position, Quaternion.identity, transform);
            }
        }

        private IEnumerator CreateRockets()
        {
            var position = GetPosition(BorderLimit + 0.2f);
            
            for (var i = 0; i < _maxRocketsCount; i++)
            {
                Instantiate(_rocketPrefab, position, Quaternion.identity, transform);
                yield return new WaitForSeconds(5f);
            }
        }

        private Vector3 GetPosition(float z)
        {
            var y = Random.Range(-BorderLimit, BorderLimit);
            return _createionZone.TransformPoint(0, y, z);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(_createionZone.position, _createionZone.localScale);
        }
    }
}