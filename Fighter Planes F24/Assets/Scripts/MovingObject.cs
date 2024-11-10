using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public int myType;
    // Start is called before the first frame update
    void Start()
    {

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
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * Random.Range(2f, 6f));
        }
        else if (myType == 4) // Enemy2
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
