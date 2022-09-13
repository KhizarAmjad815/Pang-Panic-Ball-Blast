using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    private float startDelay = 2.0f;
    private float repeatRate = 6f;
    public PlayerController pController;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBall", startDelay, repeatRate);
        pController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnBall()
    {
        int xPos = Random.Range(2, 30);

        Vector3 pos = new Vector3(xPos, 18.0f, 0.0f);
        GameObject randomBall = ballPrefabs[Random.Range(0, ballPrefabs.Length)];

        if (!GameManager.isGameOver)
        {
            Instantiate(randomBall, pos, randomBall.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
