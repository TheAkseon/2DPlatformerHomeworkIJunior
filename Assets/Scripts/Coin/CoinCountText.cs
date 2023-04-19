using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CoinCountText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinText;

    private void Start()
    {
        _coinText = GetComponent<TextMeshProUGUI>();
    }

    public void SetText(int value)
    {
        _coinText.text = value.ToString();
    }
}
