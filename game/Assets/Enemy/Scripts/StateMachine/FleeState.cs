using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : State
{
    [SerializeField] public LayerMask layermask;
    public IdleState idleState;
    public bool isFarAway;
    private Vector3 randomPosition;
    public override State RunCurrentState(EnemyManager enemyManager)
    {
        //Szuka pozycji w obr�bie pier�cieniu mi�dzy detectionRadious a jakim� offsetem

        //idzie do tej pozycji

        //Id�c sprawdza czy nie natrafi� na przeszkod�
        
        //Je�li tak, szuka nowej pozycji

        //Je�li znajdzie si� 

        if (isFarAway)
        {
            return idleState;
        }
        else
        {
            return this;
        }
    }
}
