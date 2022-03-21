using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatistic
{
    //Prosta klasa przechowuj�ca warto�� danej statystyki
    private float value;
    private float modifier;

    public EnemyStatistic(float value)
    {
        this.value = value;
        modifier = 1f;
    }

    public void setValue(float newValue)
    {
        value = newValue;
    }

    public void setModifier(float newModifier)
    {
        modifier = newModifier;
    }
    //Inaczej jak u gracza, u przeciwnika do r�nych statystyk
    //stosowany jest modifier, kt�ry w zale�no�ci od danego efektu na przeciwniku
    //ma zmienia� warto�� statystyki
    public float getValue()
    {
        return value * modifier;
    }
}
