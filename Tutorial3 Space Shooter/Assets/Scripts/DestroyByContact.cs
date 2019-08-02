using System.Collections;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;

    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundry") || other.CompareTag("Enemy"))
        {
            return;
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }


        if (other.tag == "Bolt")
        {
            Destroy(other.gameObject);
        }


        if (other.tag == "Player")
        {
            gameController.SubLive(); //if player ship collides asteroid or enemy ship reduces 1 health
            if (gameController.isDead == true) //explodes ship once playerHealth is 0
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();
                Destroy(other.gameObject);
            }
        }

        gameController.AddScore (scoreValue);
        Destroy(gameObject);
    }
}
