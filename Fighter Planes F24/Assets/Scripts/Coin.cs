using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioSource audioSource;
    public void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Player")
        {
            GameObject.Find("Game Manager").GetComponent<GameManager>().EarnScore(1);
            GameObject.Find("Game Manager").GetComponent<GameManager>().CoinPickup();
            Destroy(this.gameObject);
        }
    }
}
