using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWander : MonoBehaviour
{
    private Vector3 orientationVector;
    private Vector3 velocity;
    private float maxSpeed;
    private float maxRotation;
    private float rotation;
    private int target;
    private float error;
    private float wanderTime;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        maxRotation = 90f;
        maxSpeed = 0.01f;
        wanderTime = 3f;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= wanderTime)
        {
            rotation = (Random.Range(0, 1.1f) - Random.Range(0, 1.1f)) * maxRotation;
            timer = 0f;
            orientationVector = new Vector3(-Mathf.Sin(rotation), Mathf.Cos(rotation), 0);
            velocity = maxSpeed * orientationVector.normalized;
            //transform.rotation = Quaternion.Euler(0, 0, rotation);
        }

        if ((transform.position.x + velocity.x) <= -4 ||
            (transform.position.x + velocity.x) >= 4)
        {
            velocity.x = -velocity.x;
        }

        if ((transform.position.y + velocity.y) <= -4 ||
            (transform.position.y + velocity.y) >= 4)
        {
            velocity.y = -velocity.y;
        }

        float radian_orientation = Mathf.Atan2(-velocity.x, velocity.y);
        rotation = Mathf.Rad2Deg * radian_orientation;
        transform.rotation = Quaternion.Euler(0, 0, rotation);

        transform.position += velocity;
    }
}
