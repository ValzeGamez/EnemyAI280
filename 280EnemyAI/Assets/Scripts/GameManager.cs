using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Text livesText;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + PlayerLives.playerLives;
    }
}
