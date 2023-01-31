using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : MonoBehaviour
{
    private Vector3 distance;
    private Vector3 direction;
    private Vector3 velocity;
    private Vector3 idealVelocity;
    private float maxSpeed;
    private float targetSpeed;
    private float maxAcceleration;
    private float rotation;
    private float targetRadius;
    private float slowRadius;

    [SerializeField] private Transform target;


    // Start is called before the first frame update
    void Start()
    {
        distance = Vector3.zero;
        maxSpeed = 0.05f;
        targetSpeed = 0.0f;
        maxAcceleration = 0.01f;
        idealVelocity = Vector3.zero;
        velocity = Vector3.zero;
        targetRadius = 0.3f;
        slowRadius = targetRadius + 5f;
    }

    // Update is called once per frame
    void Update()
    {
        distance = target.position - transform.position;
        direction = (distance).normalized;
        
        if(distance.magnitude >= slowRadius)
        {
            targetSpeed = maxSpeed;
        }
        else if (targetRadius < distance.magnitude && distance.magnitude < slowRadius)
        {
            targetSpeed = maxSpeed * distance.magnitude / slowRadius;
        }
        else if (distance.magnitude <= targetRadius)
        {
            targetSpeed = 0.0f;
        }

        idealVelocity = direction * targetSpeed;
        if ((idealVelocity - velocity).magnitude > maxAcceleration)
        {
            velocity = direction * maxAcceleration;
        }
        else
        {
            velocity = (idealVelocity - velocity);
        }

        transform.position += velocity;

        float radian_orientation = Mathf.Atan2(-velocity.x, velocity.y);
        rotation = Mathf.Rad2Deg * radian_orientation;
        transform.rotation = Quaternion.Euler(0, 0, rotation);

    }
}
