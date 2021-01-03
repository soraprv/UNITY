using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int coinCount;

    public void PickupItem()
    {
        coinCount++;
    }

    public void UseCoin()
    {
        if (coinCount > 0)
        {
            coinCount--;
        }
    }

    private void Update()
    {
        
    }
}
