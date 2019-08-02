using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{

    public float scrollSpeed;
    public float tileSizeZ;
    public float time_elapsed;

    public GameController gameController;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        time_elapsed = 0f;
    }

    public void Update()
    {
        if (gameController.score >= 100)
        {
            time_elapsed = Time.time + time_elapsed;
            scrollSpeed = (Mathf.Lerp(-0.30f, -20f, time_elapsed));
        }
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
    }
}
