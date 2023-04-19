using UnityEngine;

public class CoinPool : MonoBehaviour
{
    private Coin[] _coins;
    private int _coinCount = 0;
    private CoinCountText _coinCountText;

    private void Awake()
    {
        _coinCountText = FindObjectOfType<CoinCountText>();

        _coins = gameObject.GetComponentsInChildren<Coin>();

        foreach (var coin in _coins)
        {
            coin.CoinCollected += OnCoinCollected;
        }
    }

    private void OnDisable()
    {
        foreach (var coin in _coins)
        {
            coin.CoinCollected -= OnCoinCollected;
        }
    }

    private void OnCoinCollected()
    {
        _coinCount++;
        _coinCountText.SetText(_coinCount);
    }
}
