using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimTrigger : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator=this.GetComponent<Animator>();
    }

    public void throwhandup(){
        animator.SetBool("IsThrow",true);
    }

    public void throwhanddown(){
        animator.SetBool("IsThrow",false);
    }


}
