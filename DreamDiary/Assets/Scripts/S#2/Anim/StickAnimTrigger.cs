using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickAnimTrigger : MonoBehaviour
{
    public GameObject water;
    Animator animator;
    void Start()
    {
        animator=this.GetComponent<Animator>();
    }

    public void nonefish(){//낚시에서 아무것도 잡지 못한 모션
        StartCoroutine(noneAnim());
    }

    IEnumerator noneAnim(){
        animator.SetBool("IsNone",true);
        water.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("IsNone",false);
        yield return new WaitForSeconds(0.2f);
        water.SetActive(true);
        FindObjectOfType<StickClickEvent>().IsFishing=false;
    }
    public void eggfish(){
        StartCoroutine(eggAnim());
    }

    IEnumerator eggAnim(){
        animator.SetBool("IsEgg",true);
        water.SetActive(false);
        yield return new WaitForSeconds(2);
        FindObjectOfType<S2InGameManager>().nextpuzzle();
    }


}
