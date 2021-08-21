using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Interaction
{
    public float lookRadius = 10f;
    public Transform target;

    private NavMeshAgent agent;
    private Animator animator;

    private void Start()
    {
        target = PlayerMenager.playerMenager.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    public override void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            Debug.Log("chasing " + target.name);
        }

        if(distance <= agent.stoppingDistance)
        {
            //Attack ^^
            LookAtTarget();
        }
    }
    public override void Interact()
    {
        base.Interact();


    }


    void LookAtTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
