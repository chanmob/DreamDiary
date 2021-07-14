using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanAnimTrigger : MonoBehaviour
{
    Animator animator;
    bool isBreak=false;

    void Start()
    {
        animator=this.GetComponent<Animator>();
    }

    private void Update() {
        if(!isBreak){
            if(Input.GetMouseButtonDown(0)){  
                    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    RaycastHit2D rayhit = Physics2D.Raycast(mousePos, Vector2.zero);

                    if (rayhit.collider != null && rayhit.transform == this.gameObject.transform){
                        isBreak=true;
                        breakpan();
                    }
            }
        }
    }

    void breakpan(){
        StartCoroutine(breakCoroutine());
    }
    IEnumerator breakCoroutine(){
        animator.SetBool("IsBreak",true);
        yield return new WaitForSeconds(2.5f);
        animator.SetBool("IsBreak",false);
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<S2InGameManager>().showchicken();
    }

    public void panonfire(){
        animator.SetBool("IsFire",true);
        FindObjectOfType<S2InGameManager>().endpuzzle();
    }


}
