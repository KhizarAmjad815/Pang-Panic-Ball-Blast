using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameOver = false;
    public float speed;
    public float horizontalInput;
    public float xNegativeBound = -1;
    public float xPositiveBound = 32;
    public GameObject bulletPrefab;

    private Animator playerAnimator;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movementDirection = new Vector3(0f, 0f, horizontalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime);

        /*if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerAnimator.SetBool("isWalking", true);
        }*/

        /*
        if (movementDirection != Vector3.zero)
        {
            transform.forward = movementDirection;
        }*/

        //transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * speed);

        if (transform.position.x < xNegativeBound)
        {
            transform.position = new Vector3(xNegativeBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xPositiveBound)
        {
            transform.position = new Vector3(xPositiveBound, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !GameManager.isGameOver)
        {
            playerAnimator.SetBool("isShooting", true);
            Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            
            playerAnimator.SetInteger("numBullets", 1);
        }
        else
        {
           // playerAnimator.SetBool("isShooting", false);
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {
           // isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("GAME OVER!!");
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }*/

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LargeBall"))
        {
            GameManager.health -= 10;
        }
        else if (other.gameObject.CompareTag("SmallBall"))
        {
            GameManager.health -= 5;
        }
        else if (other.gameObject.CompareTag("SmallestBall"))
        {
            GameManager.health -= 2;
        }
        GameManager.gameManager.updateHealth();
    }
}
