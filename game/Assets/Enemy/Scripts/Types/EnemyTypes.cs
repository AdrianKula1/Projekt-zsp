using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypes : MonoBehaviour
{
    private Dictionary<string, EnemyType> types;

    public EnemyTypes()
    {
        types = new Dictionary<string, EnemyType>
        {
            {"Slime", new Slime() }
        };
    }

    public EnemyType GetType(string tag)
    {
        return types[tag];
    }
}