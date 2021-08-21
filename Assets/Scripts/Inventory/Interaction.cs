using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float radius = 4f;

    bool isFocused = false;
    bool isInteract= false;
    Transform player;

    public virtual void Update()
    {
        if(isFocused && !isInteract)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if(distance <= radius)
            {
                Interact();
                isInteract = true;
            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interact with " + transform.name);
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocused = true;
        player = playerTransform;
        isInteract = false;
    }

    public void OffFocused()
    {
        isFocused = false;
        player = null;
        isInteract = false;

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
