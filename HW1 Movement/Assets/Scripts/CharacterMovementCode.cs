using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementCode : MonoBehaviour
{
    private float orientation;
    private Vector3 velocity;
    private float maxSpeed;
    private float rotation;
    private List<Vector3> points;
    private int target;
    private float error;

    // Start is called before the first frame update
    void Start()
    {
        points = new List<Vector3> { 
            new Vector3(0, 0, 0), 
            new Vector3(7, 4, 0), 
            new Vector3(-7, 4, 0), 
            new Vector3(-7, -4, 0), 
            new Vector3(7, -4, 0)
        };
        target = 0;
        maxSpeed = 0.06f;
        velocity = (points[target] - transform.position).normalized;
        velocity *= maxSpeed;
        error = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        

        
        //if(position.x == points[target].x &&
        //   position.y == points[target].y)
        //{
        //    target = (target + 1) % points.Count;
        //    velocity = position.x == points[target].x &&
        //   position.y == points[target].y
        //}

        if (points[target].x - error <= transform.position.x && transform.position.x <= points[target].x + error &&
            points[target].y - error <= transform.position.y && transform.position.y <= points[target].y + error)
        {
            target = (target + 1) % points.Count;
            velocity = (points[target] - transform.position).normalized;
            velocity *= maxSpeed;
        }

        transform.position += velocity;
        float radian_orientation = Mathf.Atan2(-velocity.x, velocity.y);
        orientation = Mathf.Rad2Deg * radian_orientation;
        //orientation = Mathf.Atan2(-velocity.x, velocity.z);
        transform.rotation = Quaternion.Euler(0, 0, orientation);
        //transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(-velocity.x, velocity.z));

    }
}
