using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : MonoBehaviour
{
    Rigidbody2D rb;
    int speed;
    int hp;

    public GameObject small;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetSpeed(3);
        SetHP(3);
    }

    public virtual void SetSpeed(int setSpeed)
    {
        speed = setSpeed;
    }

    public virtual void SetHP(int givenHp)
    {
        hp = givenHp;
    }

    // Update is called once per frame
    void Update()
    {
        PointToPlayer();
        Move(speed);

        if (hp <= 0)
        {
            ScoreManager.UpdateScore(1);
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            hp -= 1;
        }
    }

    public virtual void Die()
    {
        Instantiate(small, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void Move(int givenSpeed)
    {
        transform.Translate(Vector3.right * givenSpeed * Time.deltaTime);
    }

    void PointToPlayer()
    {
        Vector2 playerDir = Vector2.zero - (Vector2)transform.position;
        float playerAngle = Mathf.Atan2(playerDir.x, playerDir.y) * Mathf.Rad2Deg;
        rb.rotation = -playerAngle + 90f;
    }
}
