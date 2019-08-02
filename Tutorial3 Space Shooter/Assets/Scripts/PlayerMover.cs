using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerMover : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;

    public Text scoreText;

    public int score;

    public AudioClip MusicClip;

    public AudioClip MusicClip2;

    public AudioSource MusicSource;


    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private Rigidbody rb;
    private float nextFire;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {


            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            MusicSource.Play();
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;

    }

    void FixedUpdate()
    {

        if (Input.GetKey("escape"))
            Application.Quit();


        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
             Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
             0.0f,
             Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Pickup"))
        {

            other.gameObject.SetActive(false);
            score = score + 100;
            SetScoreText();

        }
    }
    void SetScoreText()
    {
        scoreText.text = "Points: " + score;
    }

}



