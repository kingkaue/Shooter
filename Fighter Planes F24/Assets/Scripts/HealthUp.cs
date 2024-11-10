using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 3f);
    }
    public void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Player")
        {
            GameObject.Find("Player(Clone)").GetComponent<Player>().GainALife();
            GameObject.Find("Game Manager").GetComponent<GameManager>().HealthPickup();
            Destroy(this.gameObject);
        }
    }
}
