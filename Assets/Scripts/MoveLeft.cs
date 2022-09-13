using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 20.0f;
    public PlayerController pController;
    public float leftBound = -15.0f;

    // Start is called before the first frame update
    void Start()
    {
        pController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pController.gameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        if (transform.position.x < pController.transform.position.x && gameObject.CompareTag("Coin"))
        {
            Destroy(gameObject);
        }
    }
}
