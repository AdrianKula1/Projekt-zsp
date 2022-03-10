using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool immunity = false;
    public Dictionary<string, PlayerStatistic> statistics;
    
    //Inicjuje statystyki gracza
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        statistics = new Dictionary<string, PlayerStatistic>();
        statistics.Add("Health", new PlayerStatistic("Health", 1, 100f));
        statistics.Add("Stamina", new PlayerStatistic("Stamina", 1, 100f));
        statistics.Add("Mana", new PlayerStatistic("Mana", 1, 100f));
    }

    public void SetImmunity(bool immunityCondition)
    {
        immunity = immunityCondition;
    }
    //Otrzymywanie obra�e�, immunity ma dzia�a� jak cooldown tak�e
    //�eby nie otrzyma� 1000 uderze� w jednej sekundzie gdy przeciwnik zaatakuje
    public void TakeDamage(float damageValue)
    {
        if (!immunity)
        {
            float health = statistics["Health"].GetValue();
            health -= damageValue;
            statistics["Health"].SetValue(health);
            StartCoroutine(TakeDamageCooldown());
        }

        if (statistics["Health"].GetValue() <= 0)
            Die();
    }

    private void Die()
    {
        Debug.Log("Player died");
    }

    public IEnumerator TakeDamageCooldown()
    {
        immunity = true;
        yield return new WaitForSeconds(1f);
        immunity = false;
    }
}
