using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public abstract void TakeDamage(float damage, Vector3 Knockback, float knockbackStrength, float knockbackDuration);
}
