using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationController : MonoBehaviour
{
    protected Animator animator;
    protected NavMeshAgent agent;
    protected CharacterCombat characterCombat;

    protected virtual void Start()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        characterCombat = GetComponent<CharacterCombat>();
    }

    protected virtual void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
        animator.SetBool("InCombat", characterCombat.inCombat);
    }


}
