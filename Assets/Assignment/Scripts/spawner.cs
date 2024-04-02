using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject large;
    public GameObject medium;
    public GameObject small;

    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform spawn4;
    public Transform spawn5;
    public Transform spawn6;
    public Transform spawn7;
    public Transform spawn8;
    public Transform spawn9;
    public Transform spawn10;
    public Transform spawn11;
    public Transform spawn12;
    public Transform spawn13;
    public Transform spawn14;
    public Transform spawn15;
    public Transform spawn16;
    public Transform spawn17;
    public Transform spawn18;
    public Transform spawn19;
    public Transform spawn20;

    float intensity;

    int i;
    int q;

    GameObject enemyToBeSpawned;
    Transform spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        intensity = 1;

        StartCoroutine(SpawnLoop());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnLoop()
    {
        intensity += 0.1f;

        i = Random.Range(1, 21);
        q = Random.Range(1, 4);

        if (q == 1)
        {
            enemyToBeSpawned = small;
        }
        else if (q == 2)
        {
            enemyToBeSpawned = medium;
        }
        else
        {
            enemyToBeSpawned = large;
        }

        if (i == 1)
        {
            spawnPos = spawn1;
        }
        else if (i == 2)
        {
            spawnPos = spawn2;
        }
        else if (i == 3)
        {
            spawnPos = spawn3;
        }
        else if (i == 4)
        {
            spawnPos = spawn4;
        }
        else if (i == 5)
        {
            spawnPos = spawn5;
        }
        else if (i == 6)
        {
            spawnPos = spawn6;
        }
        else if (i == 7)
        {
            spawnPos = spawn7;
        }
        else if (i == 8)
        {
            spawnPos = spawn8;
        }
        else if (i == 9)
        {
            spawnPos = spawn9;
        }
        else if (i == 10)
        {
            spawnPos = spawn10;
        }
        else if (i == 11)
        {
            spawnPos = spawn11;
        }
        else if (i == 12)
        {
            spawnPos = spawn12;
        }
        else if (i == 13)
        {
            spawnPos = spawn13;
        }
        else if (i == 14)
        {
            spawnPos = spawn14;
        }
        else if (i == 15)
        {
            spawnPos = spawn15;
        }
        else if (i == 16)
        {
            spawnPos = spawn16;
        }
        else if (i == 17)
        {
            spawnPos = spawn17;
        }
        else if (i == 18)
        {
            spawnPos = spawn18;
        }
        else if (i == 19)
        {
            spawnPos = spawn19;
        }
        else
        {
            spawnPos = spawn20;
        }

        Instantiate(enemyToBeSpawned, spawnPos.position, spawnPos.rotation);

        yield return new WaitForSeconds(Random.Range(0f, 5f) / intensity);
        StartCoroutine(SpawnLoop());
    }
}
