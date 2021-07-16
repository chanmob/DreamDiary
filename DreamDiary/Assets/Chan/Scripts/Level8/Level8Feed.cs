using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level8Feed : MonoBehaviour
{
    public GameObject[] fish;

    public void AnimationAction()
    {
        Level8Manager.instance.EatSound();
        for(int i = 0; i < fish.Length; i++)
        {
            fish[i].SetActive(true);
        }
    }
}
