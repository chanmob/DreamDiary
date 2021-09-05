using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDisappear : MonoBehaviour
{
    public GameObject next;

    public float delay;

    public void Next()
    {
        Invoke("NextStep", delay);
    }

    public void NextStep()
    {
        next.SetActive(true);
        gameObject.SetActive(false);
    }
}
