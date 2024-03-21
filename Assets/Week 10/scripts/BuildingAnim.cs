using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingAnim : MonoBehaviour
{
    public Transform flower;
    public Transform well;
    public Transform stairs;
    public Transform fence;

    float interFlower;
    float interWell;
    float interStairs;
    float interFence;

    void Start()
    {
        interFlower = 0.0f;
        interWell = 0.0f;
        interStairs = 0.0f;
        interFence = 0.0f;
        StartCoroutine(Build());
    }

    IEnumerator Build()
    {
        flower.localScale = new Vector3(1f, 0.01f, 1);
        well.localScale = new Vector3(1f, 0.01f, 1);
        stairs.localScale = new Vector3(1f, 0.01f, 1);
        fence.localScale = new Vector3(1f, 0.01f, 1);

        StartCoroutine(FlowerBuild());
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(FenceBuild());
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(StairsBuild());
        yield return new WaitForSeconds(0.7f);
        StartCoroutine(WellBuild());
    }

    IEnumerator FlowerBuild()
    {
        while (interFlower < 1)
        {
            flower.localScale = Vector3.Lerp(new Vector3(1f, 0.01f, 1f), new Vector3(1f, 1f, 1f), interFlower);
            interFlower += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator WellBuild()
    {
        while (interWell < 1)
        {
            well.localScale = Vector3.Lerp(new Vector3(1f, 0.01f, 1f), new Vector3(1f, 1f, 1f), interWell);
            interWell += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator FenceBuild()
    {
        while (interFence < 1)
        {
            fence.localScale = Vector3.Lerp(new Vector3(1f, 0.01f, 1f), new Vector3(1f, 1f, 1f), interFence);
            interFence += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator StairsBuild()
    {
        while (interStairs < 1)
        {
            stairs.localScale = Vector3.Lerp(new Vector3(1f,0.01f,1f), new Vector3(1f, 1f, 1f), interStairs);
            interStairs += Time.deltaTime;
            yield return null;
        }
    }
}
