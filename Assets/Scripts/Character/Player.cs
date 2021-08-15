using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    Interaction interaction;

    public GameObject[] aniamtors = new GameObject[2];

    [SerializeField] Transform target;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GiveCommand();
        }

        if (target != null)
        {
            agent.SetDestination(target.position);
            DirectionToTarget();
        }

        Animation();
    }


    private void GiveCommand()
    {
        Vector3 screenMousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        Ray ray = Camera.main.ViewportPointToRay(screenMousePos);
        RaycastHit hit;

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider is TerrainCollider)
            {
                RemoveTarget();
                agent.SetDestination(hit.point);
            }
            else
            {
                Interaction interactable = hit.collider.GetComponent<Interaction>();
                if (interactable != null)
                {
                    SetTarget(interactable);
                    Debug.Log(interactable.name);
                }

            }



        }

    }

    private void Animation()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }


    private void SetTarget(Interaction newFocus)
    {
        if (newFocus != interaction)
        {
            if (interaction != null)
                interaction.OffFocused();

            interaction = newFocus;
        }

        agent.stoppingDistance = newFocus.radius * .8f;
        target = interaction.transform;
        newFocus.OnFocused(transform);
    }

    private void RemoveTarget()
    {
        if (interaction != null)
            interaction.OffFocused();

        
            
        agent.stoppingDistance = 0f;
        target = null;
    }


    private void DirectionToTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

}
