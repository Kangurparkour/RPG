using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField] private int baseValue;

    [SerializeField] private List<int> modifiers;

    public int GetValue()
    {
        int finalValue = baseValue;

        foreach (int x in modifiers)
            finalValue += x;


        return finalValue;
    }


    public void AddModifier(int modifier)
    {
        if (modifier != 0)
            modifiers.Add(modifier);


    }

    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
            modifiers.Remove(modifier);

    }


}
