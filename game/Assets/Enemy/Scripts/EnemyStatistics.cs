using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyStatistics
{
    public enum Stat
    {
        Health,
        Speed,
        Damage,
        AttackSpeed,
        DetectionRadious,
        AttackRadious
    }

    private AIPath path;
    private Dictionary<Stat, EnemyStatistic> Statistics;

    public EnemyStatistics(float health, float speed, float damage, float attackSpeed, float detectionRadious, float attackRadious, AIPath path)
    {
        Statistics = new Dictionary<Stat, EnemyStatistic>
        {
            {Stat.Health, new EnemyStatistic(health)},
            {Stat.Speed, new EnemyStatistic(speed)},
            {Stat.Damage, new EnemyStatistic(damage)},
            {Stat.AttackSpeed, new EnemyStatistic(attackSpeed)},
            {Stat.DetectionRadious, new EnemyStatistic(detectionRadious)},
            {Stat.AttackRadious, new EnemyStatistic(attackRadious)}
        };

        this.path = path;
    }

    public float GetStat(Stat statType)
    {
        return Statistics[statType].getValue();
    }

    public void SetStat(Stat statType, float value)
    {
        Statistics[statType].setValue(value);
    }

    //TODO
    public void ApplyEffect(Effect effect)
    {
        if (effect.SetEffect(Statistics))
        {
            path.maxSpeed = GetStat(Stat.Speed);
        }
    }
}
