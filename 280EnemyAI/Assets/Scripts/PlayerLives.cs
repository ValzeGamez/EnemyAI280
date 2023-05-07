using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public static int playerLives = 6;

    [SerializeField]
    private Material playerMat;
    private Color damageColor = new Color(0.6037736f, .05354214f, 0.2232596f);
    private Color defaultColor = new Color(0.7490196f, 0.5647059f, 0.7333333f);
    private void Start()
    {
        playerMat.color = defaultColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //If player is hit by tag "bullet", player loses a life
        if (other.gameObject.tag == "bullet")
        {
            playerLives--;
            Destroy(other.gameObject);
            StartCoroutine(DamageFeedback());
        }      
        else return;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            playerLives--;
            StartCoroutine(DamageFeedback());
        }
    }

    
    //changes player material so there is feedback that they were hit
    IEnumerator DamageFeedback()
    {
        playerMat.color = damageColor;
        yield return new WaitForSeconds(.3f);
        playerMat.color = defaultColor;   
    }

}
