using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public GameObject[] smallBallPrefabs;
    public GameObject[] smallestBallPrefabs;
    public AudioClip shootSound;
    public AudioSource shootAudio;


    // Start is called before the first frame update
    void Start()
    {
        shootAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (this.gameObject.CompareTag("Bullet") && collision.gameObject.CompareTag("LargeBall"))
        {
            shootAudio.PlayOneShot(shootSound, 1.0f);

            float temp = 0.0f;
            for(int i = 0; i < smallBallPrefabs.Length; i++)
            {
                Vector3 pos = new Vector3(collision.transform.position.x + temp, collision.transform.position.y, transform.position.z);
                Instantiate(smallBallPrefabs[i], pos, smallBallPrefabs[i].transform.rotation);
                temp += 3.5f;
            }

            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        else if (this.gameObject.CompareTag("Bullet") && collision.gameObject.CompareTag("SmallBall"))
        {
            float temp = 0.0f;
            for (int i = 0; i < smallestBallPrefabs.Length; i++)
            {
                Vector3 pos = new Vector3(collision.transform.position.x + temp, collision.transform.position.y, transform.position.z);
                Instantiate(smallestBallPrefabs[i], pos, smallestBallPrefabs[i].transform.rotation);
                temp += 2f;
            }
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        else if (this.gameObject.CompareTag("Bullet") && collision.gameObject.CompareTag("SmallestBall"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
