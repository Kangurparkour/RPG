using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Stat attackDemage;
    public Stat Armor;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamge(int damage)
    {
        damage -= Armor.GetValue() / 2;

        if (damage < 0)
            return;


        currentHealth -= damage;
        Debug.Log(transform.name + " get " + damage + " damage!");

        if (currentHealth <= 0)
            Death();



    }


    public virtual void Death()
    {
        Debug.Log(transform.name + " is dead.");
    }

}
