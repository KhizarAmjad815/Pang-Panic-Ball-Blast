using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        transform.Rotate(0f, 20 * Time.deltaTime, 0f, Space.Self);

        if (transform.position.y > 15)
        {
            Destroy(this.gameObject);
        }
    }
}
