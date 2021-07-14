using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashAnimTrigger : MonoBehaviour
{
    Vector3 gv; //목표 벡터(goal vector)
    Vector3 cv; //현재 벡터(curren vector)
    public GameObject trashcan;
    public GameObject cat;
    bool IsThrow=false;
    bool IsGoal=false;
    bool IsFail=false;
    public float throwspeed=3f;

    void Start()
    {
        this.GetComponent<SpriteRenderer>().enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
     if(IsThrow){
        throwtrash();
     }else if(IsFail){
        failtrash();
     }
    }

    public void throwset(){ //쓰레기 던지기
        cv=new Vector3(-4.14f,1.3f,0);
        this.transform.position=new Vector2(cv.x,cv.y);
        gv=new Vector3(trashcan.transform.position.x,trashcan.transform.position.y-0.6f,0);
        this.GetComponent<SpriteRenderer>().enabled=true;
        IsThrow=true;
    }

    void throwtrash(){
        if(gv.x-cv.x>0.1f||gv.y-cv.y>0.5f){
            cv=Vector3.Slerp(cv,gv,throwspeed); 
            this.transform.position=new Vector2(cv.x,cv.y);
        }else {
            IsThrow=false;
            if(!IsGoal){
                Debug.Log("골인");
                IsGoal=true;
                this.GetComponent<SpriteRenderer>().enabled=false;
                FindObjectOfType<ClickToBreak>().finishthrow();
                FindObjectOfType<CatAnimTrigger>().throwhanddown();
                FindObjectOfType<InGameManager>().endgame();
            }
        }
    }

    public void failset(){
        cv=new Vector3(-4.14f,1.3f,0);
        this.transform.position=new Vector2(cv.x,cv.y);
        gv=new Vector3(-2.0f,10.0f,0);
        this.GetComponent<SpriteRenderer>().enabled=true;
        IsFail=true;
    }

    void failtrash(){
        if(gv.x-cv.x>0.1f||gv.y-cv.y>0.1f){
            cv=Vector3.Slerp(cv,gv,throwspeed); 
            this.transform.position=new Vector2(cv.x,cv.y);
        }else{
            IsFail=false;
            this.GetComponent<SpriteRenderer>().enabled=false;
            FindObjectOfType<ClickToBreak>().finishthrow();
            FindObjectOfType<CatAnimTrigger>().throwhanddown();
        }
    }
}
