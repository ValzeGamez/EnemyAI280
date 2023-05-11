using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySpawner : MonoBehaviour
{
    public GameObject attackFly;
    public Transform spawnPos;
    // Update is called once per frame
    void Update()
    {
       // StartCoroutine(Spawn());
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        int spawnTime = Random.Range(1, 5);
        int spawnAmount = Random.Range(1, 3);

        yield return new WaitForSeconds(spawnTime);
        if(spawnAmount == 1)
        {
            Instantiate(attackFly, spawnPos);
        }
        if(spawnAmount == 2)
        {
            Instantiate(attackFly, spawnPos.transform);
            Instantiate(attackFly, spawnPos.transform);
        }
       
            
            
    }
}
