using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    public float attackDelay = 1f;
    private float attackCooldown = 0f;
    const float inCombatDelay=6f;
    float lastAttackDelay;
    
    CharacterStats stats;
    public bool inCombat;

    public event System.Action OnAttack;

    private void Start()
    {
        stats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
        if(Time.deltaTime - lastAttackDelay >= inCombatDelay)
        {
            inCombat = false;
        }
        Debug.Log("In combat is" + inCombat);

    }

    public void Attack(CharacterStats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));

            if (OnAttack != null)
                OnAttack();

            attackCooldown = 1f / attackSpeed;
            inCombat = true;
            lastAttackDelay = Time.deltaTime;
        }
    }

    IEnumerator DoDamage(CharacterStats stat, float delay)
    {
        yield return new WaitForSeconds(delay);

        stat.TakeDamge(stats.attackDemage.GetValue());
        if(stats.currentHealth >= 0)
        {
            inCombat = false;
        }
    }


}
