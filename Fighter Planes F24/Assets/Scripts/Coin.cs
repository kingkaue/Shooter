using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 3f);
    }
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
