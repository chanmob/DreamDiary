using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level8Anim : MonoBehaviour
{
    public GameObject feed1;
    public GameObject feed2;

    public void FirstFeed()
    {
        Level8Manager.instance.FeedSound();
        feed1.SetActive(true);
    }

    public void SecondFeed()
    {
        Level8Manager.instance.FeedSound();
        feed2.SetActive(true);
    }

    public void Finish()
    {
        gameObject.SetActive(false);
    }
}
