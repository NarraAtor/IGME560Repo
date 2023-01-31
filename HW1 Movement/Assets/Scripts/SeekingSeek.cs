using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingSeek : MonoBehaviour
{
    private Vector3 orientationVector;
    private Vector3 direction;
    private Vector3 velocity;
    private float maxSpeed;
    private float maxAcceleration;
    private float rotation;
    [SerializeField] private Transform target;


    // Start is called before the first frame update
    void Start()
    {
        maxSpeed = 0.9f;
        maxAcceleration = 0.01f;
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        direction = (target.position - transform.position).normalized;
        velocity += direction * maxAcceleration;
        
        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized* maxSpeed;
        }
        transform.position += velocity;

        float radian_orientation = Mathf.Atan2(-velocity.x, velocity.y);
        rotation = Mathf.Rad2Deg * radian_orientation;
        transform.rotation = Quaternion.Euler(0, 0, rotation);

    }
}
