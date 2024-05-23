using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static BasicAI;

public class AggroManager : MonoBehaviour
{

    BasicAI parentAI;

    void Start() {

        parentAI = transform.parent.gameObject.GetComponent<BasicAI>();
    }   

    private void OnTriggerEnter(Collider collider) {
        
        parentAI.SetAggroTarget(collider.gameObject);
    }
}
