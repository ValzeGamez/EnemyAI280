using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemy : MonoBehaviour
{
    [SerializeField]
    private int enemyHealth = 10;
    [SerializeField]
    private float moveSpeed;

    //player detection
    public bool lookAt;
    Rigidbody rb;
    public GameObject player;

    public Material mat;

    private void Awake()
    {

        rb = gameObject.GetComponent<Rigidbody>();

    }
    // Start is called before the first frame update
    void Start()
    {
        mat.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth == 5)
        {
            PlayerDetection.targetFound = false;
            lookAt = false;
            //gameObject.GetComponent<PlayerDetection>().enabled = false;            
            StartCoroutine(Wait());         
        }
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }

        if (PlayerDetection.targetFound)
        {
            //look at the player
            lookAt = true;
        }
        if (lookAt)
        {
            transform.LookAt(player.transform);
            Vector3 vel = rb.velocity;
            if (PlayerDetection.targetFound && vel.x > -2 && vel.x < 2 && vel.z > -2 && vel.z < 2)
            {
                // rb.AddForce((moveSpeed * Time.deltaTime) * transform.forward);
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            }
        }

    }

    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            enemyHealth--;
            Destroy(collision.gameObject);
            StartCoroutine(DamageFeedback());
            if (this.gameObject.tag == "detection")
            {
                Debug.Log("detection");
            }
        }
    }
    IEnumerator DamageFeedback()
    {
        mat.color = Color.red;
        yield return new WaitForSeconds(.3f);
        mat.color = Color.white;
    }

    IEnumerator Wait()
    {
        mat.color = Color.red;
        yield return new WaitForSeconds(4);
        enemyHealth = 10;
        //gameObject.GetComponent<PlayerDetection>().enabled = true;
        mat.color = Color.white;
        PlayerDetection.targetFound = true;
        lookAt = true;
        yield break;
    }
}
