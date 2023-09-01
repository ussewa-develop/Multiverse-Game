
using System;
using UnityEngine;

public static class Wallet
{
    public static Action<int> coinsChangedEvent;
    private static int coins = 10000;
    public static int Coins 
    { 
        get
        {
            return coins;
        }
        private set
        {
            if(value < 0)
            {
                coins = 0;
            }
            else
            {
                coins = value;
            }
            coinsChangedEvent?.Invoke(coins);
        }
    }

    public static void AddCoins(int value)
    {
        Coins+=value;
    }
}
