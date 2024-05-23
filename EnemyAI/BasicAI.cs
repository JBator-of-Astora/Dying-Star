using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour
{

    UnityEngine.AI.NavMeshAgent navMeshAgent;
    GameObject target;

    [SerializeField] float aggroDropTime;
    [SerializeField] float aggroPassTime;
    float aggroDropTimer;
    float aggroPassTimer;

    void Start() {

        navMeshAgent = gameObject.transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        aggroDropTimer = 0;
    }

    void Update() {

        aggroDropTimer -= Time.deltaTime;
        aggroPassTimer -= Time.deltaTime;

        if (aggroDropTimer < 0) aggroDropTimer = 0;
        if (aggroPassTimer < 0) aggroPassTimer = 0;
        
        float xOffset = target.transform.position.x - transform.position.x;
        float zOffset = target.transform.position.z - transform.position.z;

        if (xOffset < 5 || xOffset > -5 &&  zOffset < 5 || zOffset > -5) {

            aggroDropTimer = aggroDropTime;
        } 

        if (target != null && aggroDropTimer > 0) {
            navMeshAgent.SetDestination(target.transform.position);
        }
    }
   public void SetAggroTarget(GameObject gameObject) {

        // Collider is Current Target
         if (target == gameObject) {

            aggroDropTimer = aggroDropTime;
        }
        // Collider is not current target 
        if (target != gameObject) {

            if (target == null || aggroPassTimer <= 0) {
                target = gameObject;
                aggroDropTimer = aggroDropTime;
                aggroPassTimer = aggroPassTime; 
            }
        }       
   }
}
