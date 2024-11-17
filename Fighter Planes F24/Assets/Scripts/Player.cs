using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float horizontalInput;
    private float verticalInput;
    private float speed;
    private float horizontalScreenLimit;
    private float verticalScreenLimit;
    public int lives;
    private int shooting;

    public GameManager gameManager;

    public GameObject explosion;

    public GameObject bullet;

    public GameObject thruster;

    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;
        horizontalScreenLimit = 13f;
        verticalScreenLimit = 6.3f;
        lives = 3;
        shooting = 1;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);

        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }

        if (transform.position.y > verticalScreenLimit || transform.position.y <= -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
        }
    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            switch (shooting)
            {
                case 1:
                    Instantiate(bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(bullet, transform.position + new Vector3(-0.5f, 1, 0), Quaternion.identity);
                    Instantiate(bullet, transform.position + new Vector3(0.5f, 1, 0), Quaternion.identity);
                    break;
                case 3:
                    Instantiate(bullet, transform.position + new Vector3(-0.5f, 1, 0), Quaternion.identity);
                    Instantiate(bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                    Instantiate(bullet, transform.position + new Vector3(0.5f, 1, 0), Quaternion.identity);
                    break;

            }
        }
        
    }

    public void LoseALife()
    {
        lives--;
        GameObject.Find("Game Manager").GetComponent<GameManager>().UpdateLives(lives);
        if (lives == 0)
        {
            gameManager.GameOver();
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void GainALife()
    {
        if (lives < 3)
        {
            lives++;
            GameObject.Find("Game Manager").GetComponent<GameManager>().UpdateLives(lives);
        }
        else
        {
            GameObject.Find("Game Manager").GetComponent<GameManager>().EarnScore(1);
        }
    }

    IEnumerator SpeedPowerDown()
    {
        yield return new WaitForSeconds(3f);
        thruster.gameObject.SetActive(false);
        speed = 6f;
    }

    IEnumerator ShootingPowerDown()
    {
        yield return new WaitForSeconds(4f);
        shooting = 1;
    }

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if(whatDidIHit.tag == "Powerup")
        {
            int powerupType = Random.Range(1, 5); // this can be 1,2,3, or 4
            switch (powerupType)
            {
                case 1:
                    //speed boost powerup
                    speed = 9f;
                    gameManager.UpdatePowerupText("Picked up Speed Boost!");
                    thruster.gameObject.SetActive(true);
                    StartCoroutine(SpeedPowerDown());
                    break;
                case 2:
                    //double shot
                    shooting = 2;
                    gameManager.UpdatePowerupText("Picked up Double Shot!");
                    StartCoroutine (ShootingPowerDown());
                    break;
                case 3:
                    // tripple shot
                    shooting = 3;
                    gameManager.UpdatePowerupText("Picked up Triple Shot!");
                    StartCoroutine(ShootingPowerDown());
                    break;
                case 4:
                    //shield
                    gameManager.UpdatePowerupText("Picked up Shield!");
                    break;
            }
        }
    }

}
