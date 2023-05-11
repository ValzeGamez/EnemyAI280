using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoterFly : MonoBehaviour
{
    //spawn attack flies on death
    public Transform spawner1, spawner2;
    public GameObject attackFlyPrefab;
    public GameObject imaginaryFlies;
    private void Update()
    {
        /*
        if(Enemy1.enemyHealth <= 0)
        {
            Instantiate(attackFlyPrefab, spawner1);
            Instantiate(attackFlyPrefab, spawner2);
            Destroy(imaginaryFlies);
        }
        */
    }
}
