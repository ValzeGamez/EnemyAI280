using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFlyMat : MonoBehaviour
{
    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SwitchMat());
    }

    IEnumerator SwitchMat()
    {
        mat.color = Color.red;
        yield return new WaitForSeconds(1f);
        mat.color = Color.black;
        yield return new WaitForSeconds(1f);
    }
}
