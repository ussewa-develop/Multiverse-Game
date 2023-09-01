using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WalletUI : MonoBehaviour
{
    private TextMeshProUGUI _thisText;

    private void Start()
    {
        Wallet.coinsChangedEvent += ChangeText;
        _thisText = GetComponent<TextMeshProUGUI>();
        _thisText.text = Wallet.Coins.ToString();
    }

    private void OnDestroy()
    {
        Wallet.coinsChangedEvent -= ChangeText;
    }

    private void ChangeText(int coins)
    {
        _thisText.text = coins.ToString();
    }
}
