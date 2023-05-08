using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Text livesText;
    public Text gameOverText;

    public GameObject player;
    private PlayerController controls;
    public static bool gameOver;
    public static bool r_Pressed;
    private void Start()
    {
        controls = player.GetComponent<PlayerController>();
        gameOverText.text = "";
        controls.enabled = true;
        gameOver = false;
        r_Pressed = false;
    }
    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + PlayerLives.playerLives;

        //game ends when lives reach 0, and the controls are disabled so the player can't keep going
        if(PlayerLives.playerLives <= 0)
        {           
            controls.enabled = false;
            gameOver = true;
        }
        if (gameOver)
        {
            gameOverText.text = "You Died! Press 'R' to restart";
            if (Input.GetKeyDown(KeyCode.R))
            {
                Restart();
            }
        }      
    }

    //resets the game so it can be played again
    void Restart()
    {
        PlayerLives.playerLives = 6;
        controls.enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOver = false;
    }
}
