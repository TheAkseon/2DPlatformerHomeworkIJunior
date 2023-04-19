using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;

    private SpawnPoint[] _spawnPoints;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Vector2 spawnPoint = _spawnPoints[i].transform.position;
            Coin coin = Instantiate(_prefab, spawnPoint, Quaternion.identity);
        }
    }
}
