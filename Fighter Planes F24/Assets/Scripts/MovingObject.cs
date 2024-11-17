using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public int myType;
    private GameManager gameManager;
   
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myType == 1) // Bullet
        {
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 10f);
        }
        else if (myType == 2) // Enemy
        {
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 3f);
        }
        else if (myType == 3) // Cloud
        {
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * Random.Range(3f, 6f) * gameManager.cloudSpeed);
        }else if (myType ==4)
        {
            //I am thou powerup
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 6f);
        }
        else if (myType == 5) // Enemy2
        {
            float horizontalPosition = Mathf.Sin(Time.time * 1f) * 1f;
            transform.Translate(new Vector3(horizontalPosition, -1, 0) * Time.deltaTime * 3f);
        }

        if ((transform.position.y > 9 || transform.position.y <= -9) && myType != 3)
        {
            Destroy(this.gameObject);
        }
        else if (transform.position.y <= -9 && myType == 3)
        {
            transform.position = new Vector3(Random.Range(-10f, 10f), 9f, 0);
        }
    }
}
