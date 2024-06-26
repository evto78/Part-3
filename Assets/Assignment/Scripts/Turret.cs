using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    bool shooting = false;
    bool heatStun = false;

    float heat = 0.0f;
    float firerate = 0.2f;
    float cooldown = 0f;

    int hp = 5;
    int xp = 0;

    Rigidbody2D rb;

    public Slider heatSlider;

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
        if (Input.GetMouseButton(0) && !shooting && cooldown <= 0 && !heatStun)
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

        HeatChange();

        shooting = false;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void HeatChange()
    {
        if (shooting)
        {
            heat += 3;
        }
        else
        {
            heat -= 10 * Time.deltaTime;
        }

        if (heat >= 100)
        {
            heatStun = true;
            heat = 100;
        }

        if (heat <= 0)
        {
            heatStun = false;
            heat = 0;
        }

        heatSlider.value = heat;

        Debug.Log("heat " + heat);
        Debug.Log("heat stun is " + heatStun);
    }

    void Shoot()
    {
        xp += 1;

        Instantiate(bullet, firePoint0.transform.position, firePoint0.transform.rotation);
        if (xp >= 50)
        {
            Instantiate(bullet, firePointP1.transform.position, firePointP1.transform.rotation);
            Instantiate(bullet, firePointN1.transform.position, firePointN1.transform.rotation);
        }
        if (xp >= 100)
        {
            Instantiate(bullet, firePointP2.transform.position, firePointP2.transform.rotation);
            Instantiate(bullet, firePointN2.transform.position, firePointN2.transform.rotation);
        }
    }

    void LookAtCursor()
    {
        Vector2 mouseDir = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
        float mouseAngle = Mathf.Atan2(mouseDir.x, mouseDir.y) * Mathf.Rad2Deg;
        rb.rotation = -mouseAngle + 90f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            hp -= 1;
            Destroy(collision.gameObject);
        }
    }
}
