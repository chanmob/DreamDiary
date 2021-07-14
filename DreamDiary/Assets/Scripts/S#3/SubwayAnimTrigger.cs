using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubwayAnimTrigger : MonoBehaviour
{
    public bool IsTime=false;
    Vector2 startposition;
    Vector2 finishposition;
    public float distance; //드래그 인정할 범위
    int length=0;
    Animator animator;

    void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsTime&&Input.GetMouseButtonDown(0)){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D rayhit = Physics2D.Raycast(mousePos, Vector2.zero);
                if (rayhit.collider != null && rayhit.transform == this.gameObject.transform){
                    startposition=mousePos;
                }
        }
        if(IsTime&&Input.GetMouseButton(0)){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(mousePos.y<startposition.y-distance){
                startposition=mousePos;
                getlonger();
            }
        }
    }

    void getlonger(){
        length++;
        animator.SetInteger("Length",length);
        if(length>=4){
            IsTime=false;
            FindObjectOfType<S3InGameManager>().endpuzzle();
        }
    }
}
