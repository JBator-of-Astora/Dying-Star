using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicIssueSword : Item
{
    // Start is called before the first frame update
    void Start()
    {
        
        base.Start();
    }

    public override void get_attack() {
        
        Debug.Log("Gain 7.5 attack");
    }
}
