using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public TMP_Text healthText;
    public static int health = 100;
    public static bool isGameOver = false;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateHealth()
    {
        if (health <= 0)
        {
            healthText.text = "GAME OVER";
            isGameOver = true;
        }
        else
        {
            healthText.text = "Health: " + health.ToString();
        }
    }
}
