using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool immunity = false;
    private bool isAlive = true;
    public Dictionary<string, PlayerStatistic> playerStats;
    
    //Inicjuje statystyki gracza
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        playerStats = new Dictionary<string, PlayerStatistic>();
        playerStats.Add("Health", new PlayerStatistic("Health", 1, 100f));
        playerStats.Add("Stamina", new PlayerStatistic("Stamina", 1, 100f));
        playerStats.Add("Mana", new PlayerStatistic("Mana", 1, 100f));
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
            float health = playerStats["Health"].GetValue();
            health -= damageValue;
            playerStats["Health"].SetValue(health);
            StartCoroutine(TakeDamageCooldown());
        }

        if (playerStats["Health"].GetValue() <= 0)
        {
            Die();
            isAlive = false;
        }
    }

    private void Die()
    {
        Debug.Log("Player died");
    }

    public bool IsPlayerAlive()
    {
        return isAlive;
    }    

    public IEnumerator TakeDamageCooldown()
    {
        immunity = true;
        yield return new WaitForSeconds(1f);
        immunity = false;
    }
}
