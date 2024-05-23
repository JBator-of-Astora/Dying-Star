using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Damageable
{
    // Start is called before the first frame update
    void Start()
    {

        base.Start();
        baseHealth += level * healthGrowth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
