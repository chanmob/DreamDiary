using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonUp : MonoBehaviour
{
    public float animTime;
    public Animator anim;

    public GameObject disappear;

    private void OnEnable()
    {
        Invoke("StartAnim", animTime);
    }

    public void StartAnim()
    {
        anim.SetTrigger("Up");
    }

    public void NextStep()
    {
        disappear.SetActive(true);
        gameObject.SetActive(false);
    }
}
