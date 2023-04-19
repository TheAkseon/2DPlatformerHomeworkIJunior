using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    private event UnityAction _coinCollected;

    public event UnityAction CoinCollected
    {
        add => _coinCollected += value;
        remove => _coinCollected -= value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            _coinCollected?.Invoke();

            Destroy(gameObject);
        }
    }
}
