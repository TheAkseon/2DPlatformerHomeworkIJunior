using UnityEngine;
using UnityEngine.Events;

public class SpawnPoint : MonoBehaviour
{
    private event UnityAction _coinSpawned;

    public event UnityAction CoinSpawned
    {
        add => _coinSpawned += value;
        remove => _coinSpawned -= value;
    }

    public bool IsNeedSpawn { get; private set; }

    private void FixedUpdate()
    {
        if(gameObject.transform.childCount == 0)
        {
            IsNeedSpawn = true;
            _coinSpawned?.Invoke();

            Debug.Log(IsNeedSpawn);
        }
        else
        {
            IsNeedSpawn = false;
        }
    }
}
