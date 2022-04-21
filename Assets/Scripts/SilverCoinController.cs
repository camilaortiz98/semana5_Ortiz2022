using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverCoinController : MonoBehaviour
{

    public int coinSValue = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeSilverScore(coinSValue);
        }
    }
}
