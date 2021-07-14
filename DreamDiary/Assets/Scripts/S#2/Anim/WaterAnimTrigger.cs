using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAnimTrigger : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator=this.GetComponent<Animator>();
    }

    public void setMoving(){
        animator.SetBool("IsMove",true);
    }
    public void cancelMoving(){
        animator.SetBool("IsMove",false);
    }

}
