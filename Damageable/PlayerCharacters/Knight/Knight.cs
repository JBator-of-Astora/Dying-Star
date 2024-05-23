using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Player
{

    void Start() {

        base.Start();
    }
    
    protected override void MouseOne() { 

        animator.SetTrigger("M1");
        Debug.Log("M1");
        m1Cooldown = m1CooldownTime;
    }

    void Update() {

        base.Update();
    }
}
