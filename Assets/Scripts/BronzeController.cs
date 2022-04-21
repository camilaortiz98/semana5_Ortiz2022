using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BronzeController : MonoBehaviour
{
    public int coinBValue = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeBronzeScore(coinBValue);
        }
    }
}
