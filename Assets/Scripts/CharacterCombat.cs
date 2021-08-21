using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    CharacterStats stats;

    private void Start()
    {
        stats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        
    }

    public void Attack( CharacterStats targetStats)
    {
        targetStats.TakeDamge(stats.attackDemage.GetValue());
    }

}
