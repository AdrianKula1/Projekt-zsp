using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics
{
    public enum Stat
    {
        Health,
        Stamina,
        Mana,
        TotalSpeed,
        TotalStrength,
        TotalAgility,
        TotalDefense
    }

    private Dictionary<Stat, PlayerStatistic> Statistics;

    public PlayerStatistics(float health, float mana, float stamina)
    {
        Statistics = new Dictionary<Stat, PlayerStatistic>
        {
            { Stat.Health, new BarStatistic(health) },
            { Stat.Mana, new BarStatistic(mana) },
            { Stat.Stamina, new BarStatistic(stamina) },
            { Stat.TotalSpeed, new  LevelStatistic(1, 5f)}
        };
    }

    public void SetValue(Stat statType, float value)
    {
        if (statType == Stat.Health || statType == Stat.Mana || statType == Stat.Stamina)
        {
            BarStatistic statistic = (BarStatistic)Statistics[statType];
            statistic.SetValue(value);
        }

    }

    public float GetValue(Stat statType)
    {
        if (statType == Stat.Health || statType == Stat.Mana || statType == Stat.Stamina)
        {
            BarStatistic statistic = (BarStatistic)Statistics[statType];
            return statistic.GetValue();
        }
        else
        {
            LevelStatistic statistic = (LevelStatistic)Statistics[statType];
            return statistic.GetTotalValue();
        }
    }

    public float GetMaxValue(Stat statType)
    {
        if (statType == Stat.Health || statType == Stat.Mana || statType == Stat.Stamina)
        {
            BarStatistic statistic = (BarStatistic)Statistics[statType];
            return statistic.GetMaxValue();
        }
        else
        {
            return -1f;
        }
    }

    public int GetLevel(Stat statType)
    {
        return Statistics[statType].GetLevel();
    }

    public void ApplyEffect(Effect effect)
    {
        effect.SetEffectOnPlayer(Statistics);
    }
}
