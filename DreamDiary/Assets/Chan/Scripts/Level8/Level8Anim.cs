using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level8Anim : MonoBehaviour
{
    public GameObject feed1;
    public GameObject feed2;

    public void FirstFeed()
    {
        feed1.SetActive(true);
    }

    public void SecondFeed()
    {
        feed2.SetActive(true);
    }

    public void Finish()
    {
        gameObject.SetActive(false);
    }
}
