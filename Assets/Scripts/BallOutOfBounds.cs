using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallOutOfBounds : MonoBehaviour
{
    public float xNegativeBound = -1;
    public float xPositiveBound = 32;
    public float yBound = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < xNegativeBound)
        {
            transform.position = new Vector3(xNegativeBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xPositiveBound)
        {
            transform.position = new Vector3(xPositiveBound, transform.position.y, transform.position.z);
        }

        if (transform.position.y > yBound)
        {
            transform.position = new Vector3(transform.position.x, yBound, transform.position.z);
        }
    }
}
