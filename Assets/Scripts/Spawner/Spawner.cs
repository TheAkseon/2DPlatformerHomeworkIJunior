using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;

    private SpawnPoint[] _spawnPoints;
    private Coroutine _spawnCoin;
    private float _timeToSpawn = 3.0f;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();

        foreach (var spawnPoint in _spawnPoints)
        {
            spawnPoint.CoinSpawned += OnNeedCoinSpawned;
        }
    }

    private void OnDisable()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            spawnPoint.CoinSpawned -= OnNeedCoinSpawned;
        }
    }

    private void OnNeedCoinSpawned()
    {
        foreach(var spawnPoint in _spawnPoints)
        {
            if(spawnPoint.IsNeedSpawn == true)
            {
                Vector2 spawnPosition = spawnPoint.transform.position;
                var spawnedCoin = Instantiate(_prefab, spawnPosition, Quaternion.identity);
                spawnedCoin.transform.SetParent(spawnPoint.transform);

                //if(_spawnCoin != null)
                //{
                //    StopCoroutine(_spawnCoin);
                //}

                //_spawnCoin = StartCoroutine(SpawnCoin(spawnPosition));
            }
        }
    }

    private IEnumerator SpawnCoin(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(_timeToSpawn);

        var spawnedCoin = Instantiate(_prefab, spawnPosition, Quaternion.identity);

        //spawnedCoin.gameObject.transform.SetParent(_spawnCoin);
    }
}
