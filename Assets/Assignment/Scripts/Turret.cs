using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    bool shooting = false;

    float heat = 0.0f;
    float firerate = 0.2f;
    float cooldown = 0;

    int hp = 0;
    int xp = 0;

    Rigidbody2D rb;

    public GameObject bullet;

    public GameObject firePointP2;
    public GameObject firePointP1;
    public GameObject firePoint0;
    public GameObject firePointN1;
    public GameObject firePointN2;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        LookAtCursor();
        if (Input.GetMouseButton(0) && !shooting && cooldown <= 0)
        {
            shooting = true;
            cooldown = firerate;
            Shoot();
        }
        cooldown -= Time.deltaTime;
        if (cooldown < 0)
        {
            cooldown = 0;
        }

        shooting = false;
    }

    void Shoot()
    {
        Instantiate(bullet, firePoint0.transform.position, firePoint0.transform.rotation);
    }

    void LookAtCursor()
    {
        Vector2 mouseDir = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
        float mouseAngle = Mathf.Atan2(mouseDir.x, mouseDir.y) * Mathf.Rad2Deg;
        rb.rotation = -mouseAngle + 90f;
    }
}
