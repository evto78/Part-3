using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : EnemyMain
{
    public override void Start()
    {
        base.Start();
        SetSpeed(2);
        SetHP(1);
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
