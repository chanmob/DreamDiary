using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTrigger : MonoBehaviour
{
    public InGameManager ingamemanager;
    Animator animator;
    public float movingspeed;
    bool IsMoving=false;
    bool IsBroken=false;
    float rx,ry;
    float x=0,y=0;
    Vector2 rv; //새로 이동할 쓰레기통의 랜덤 위치
    Vector2 cv; //현재 위치

    void Start()
    {
        animator=this.GetComponent<Animator>();
    }

    void Update()
    {
        if(IsMoving){
            movingmotion();
        }
    }

    void OnMouseEnter() {
        if(!ingamemanager.isstart){
            if(!IsMoving&&!IsBroken){
                animator.SetBool("MouseOver",true);
                setnewpoint();
                IsMoving=true;
            }
        }
    }

    void movingmotion(){ //쓰레기통 랜덤 이동시키는 함수
        if(rx-cv.x>0.1f||ry-cv.y>0.1f){
            cv=Vector2.MoveTowards(cv,rv,movingspeed);
            this.transform.position=cv;
        }else { //해당 위치에 도달했다면
            setnewpoint();
        }
    }
    void setnewpoint(){ //새로운 랜덤 위치를 찾는 함수
        rx=Random.Range(-3.0f,6.0f); //랜덤의 x,y값 추출
        ry=Random.Range(0.0f,3.0f);
        x=transform.position.x; //현재 쓰레기통의 x,y값 추출
        y=transform.position.y;

        rv=new Vector2(rx,ry);
        cv=new Vector2(x,y);
        //Debug.Log("새로운 위치 : ("+rx+","+ry+")");
    }
    public void stopmoving(){ //쓰레기통 파괴로 인한 쓰레기통 정지
        IsMoving=false;
        IsBroken=true;
    }

    public void brokeanim(int broken){ //쓰레기통 파괴 애니메이션
        animator.SetBool("MouseOver",false);
        animator.SetInteger("broke",broken);
    }

    public void goalanim(){ //쓰레기 던지는 모션
        FindObjectOfType<CatAnimTrigger>().throwhandup();
        FindObjectOfType<TrashAnimTrigger>().throwset();
    }

    public void failanim(){
        FindObjectOfType<CatAnimTrigger>().throwhandup();
        FindObjectOfType<TrashAnimTrigger>().failset();
    }


}
