using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _playerStartPoint;
    [SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _rightBorder;
    [SerializeField] private Transform _topBorder;
    [SerializeField] private Transform _bottomBorder;
    
    [SerializeField] private int _coinsCount;
    [SerializeField] private int _bombsCount;

    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private GameObject _rocketPrefab;

    private void Start()
    {
        CreateStaticObjects();
        CreateRockets();
    }

    //TODO:
    private void CreateStaticObjects()
    {
        var x = _playerStartPoint.position.x;
        var leftLimit = _leftBorder.position.z;
        var rightLimit = _rightBorder.position.z;
        var topLimit = _topBorder.position.y;
        var bottomLimit = _bottomBorder.position.y;
        
        
        for (var i = 0; i < _coinsCount; i++)
        {
            var z = Random.Range(leftLimit, rightLimit);
            var y = Random.Range(bottomLimit, topLimit);

            Instantiate(_coinPrefab, new Vector3(x, y, z), quaternion.identity, transform);
        }

        for (var i = 0; i < _bombsCount; i++)
        {
            var z = Random.Range(leftLimit, rightLimit);
            var y = Random.Range(bottomLimit, topLimit);

            Instantiate(_bombPrefab, new Vector3(x, y, z), quaternion.identity, transform);
        }
    }

    private void CreateRockets()
    {
        var x = _playerStartPoint.position.x;
        var leftLimit = _leftBorder.position.z;
        var rightLimit = _rightBorder.position.z;
        var topLimit = _topBorder.position.y;
        var bottomLimit = _bottomBorder.position.y;

        Instantiate(_rocketPrefab, new Vector3(x, leftLimit + 10, topLimit + 10), Quaternion.identity, transform);
    }
}