using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeEnemy : EnemyMain
{
    public override void Start()
    {
        base.Start();
        SetSpeed(1);
        SetHP(8);
    }

    public override void Die()
    {
        Instantiate(small, transform.position + new Vector3(0.5f, 0.5f, 0), transform.rotation);
        Instantiate(small, transform.position + new Vector3(-0.5f, 0.5f, 0), transform.rotation);
        Instantiate(small, transform.position + new Vector3(0.5f, -0.5f, 0), transform.rotation);
        Destroy(gameObject);
    }
}
