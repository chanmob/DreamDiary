using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level8Feed : MonoBehaviour
{
    public GameObject fish;

    public void AnimationAction()
    {
        Level8Manager.instance.EatSound();
        fish.SetActive(true);
    }
}
