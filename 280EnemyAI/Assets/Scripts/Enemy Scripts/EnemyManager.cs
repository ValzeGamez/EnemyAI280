using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static bool moterFlySpawned;
    public Enemy1 enemyScript;
    // Start is called before the first frame update
    void Start()
    {
        moterFlySpawned = false;
        enemyScript = GetComponent<Enemy1>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moterFlySpawned == true)
        {
            
        }
    }
}
