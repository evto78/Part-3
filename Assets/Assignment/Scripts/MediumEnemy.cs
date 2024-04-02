using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemy : EnemyMain
{
    public override void Start()
    {
        base.Start();
        SetSpeed(1);
        SetHP(3);
    }

    public override void Die()
    {
        Instantiate(small, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
