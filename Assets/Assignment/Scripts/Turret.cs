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
    }

    void HeatChange()
    {
        if (shooting)
        {
            heat += 1000 * Time.deltaTime;
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
        Instantiate(bullet, firePoint0.transform.position, firePoint0.transform.rotation);
    }

    void LookAtCursor()
    {
        Vector2 mouseDir = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
        float mouseAngle = Mathf.Atan2(mouseDir.x, mouseDir.y) * Mathf.Rad2Deg;
        rb.rotation = -mouseAngle + 90f;
    }
}
