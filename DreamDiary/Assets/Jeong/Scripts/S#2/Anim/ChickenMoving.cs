using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMoving : MonoBehaviour
{
    public float movingspeed;
    float rx,ry;
    float cx,cy;
    float x=0,y=0;    
    Vector2 rv;
    Vector2 cv; 
    public bool IsStart=false;
    public bool IsGoal=false;
    public bool IsStop=false;
    public int direction=0; //방향 전환을 한번만 하기 위한 변수

    void Start()
    {
        
    }

    void Update()
    {
        if(IsStart&&!IsStop){
            if(!IsGoal){
                rotation();
                movingmotion();
            }else if(IsGoal){
                rotation();
                movinginside();
            }
        }
    }

    void movinginside(){
        if((rx-cv.x>0.1f||ry-cv.y>0.1f)){ 
            cv=Vector2.MoveTowards(cv,rv,movingspeed);
            if(!(isinside(cv.x,cv.y))){
                setnewpoint();
            }
            else this.transform.position=cv;
        }else { //원하는 위치에 도달했거나, 원의 범위에 들어가려고 하는 경우
            setnewpoint(); //새로운 위치 설정
        }
    }
     void movingmotion(){ //닭 랜덤 이동시키는 함수
        if((rx-cv.x>0.1f||ry-cv.y>0.1f)){ 
            cv=Vector2.MoveTowards(cv,rv,movingspeed);
            if((isinside(cv.x,cv.y))){
                setnewpoint();
            }
            else this.transform.position=cv;
        }else { //원하는 위치에 도달했거나, 원의 범위에 들어가려고 하는 경우
            setnewpoint(); //새로운 위치 설정
        }
    }
    public void endmoving(){ //닭을 옮긴 후 실행하는 함수
        IsStop=false;
        if(isinside(transform.position.x,transform.position.y)){
            IsGoal=true;
            FindObjectOfType<S2InGameManager>().addchic();
            this.GetComponent<ChickenCatch>().enabled=false;
        } 
        setnewpoint();
    }
    void setnewpoint(){ //새로운 랜덤 위치를 찾는 함수
        rx=Random.Range(-8.0f,8.0f); //랜덤의 x,y값 추출
        ry=Random.Range(-4.0f,4.0f);

        x=transform.position.x; //현재 닭의 x,y값 추출
        y=transform.position.y;

        rv=new Vector2(rx,ry);
        cv=new Vector2(x,y);
    }

    bool isinside(float x,float y){ //팬 내부에 있는지 알려주는 함수
        if(Mathf.Pow(x-1,2)+Mathf.Pow(y+5,2)<=49){ //원의 방정식 내부
            return true;
        }else{
            return false;
        }
    }

    void rotation(){
        if(rv.x>cv.x-0.1f&&direction<=0){ //오른쪽
            direction=1;
            this.GetComponent<Animator>().SetInteger("direction",1);
        }else if(rv.x<cv.x+0.1f&&direction>=0){ //왼쪽
            direction=-1;
            this.GetComponent<Animator>().SetInteger("direction",-1);
        }
    }

}
