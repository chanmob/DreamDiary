using UnityEngine;
using System.Collections;
public class ClickToBreak : MonoBehaviour 
{
    public InGameManager ingamemanager;
    float currentTime;
    public float maxTime;
    int stack=0;
    bool IsClicked=false;
    bool IsCourtine=false;
    bool IsWait=false; //클릭 입력 안받는 시간
    bool IsThrow=false; //쓰레기 던지는 중
    int broken=0;
    void Start()
    {
    }
    void Update()
    {
        if(!ingamemanager.isstart){ //시작중이지 않으면 입력받기
            if(Input.GetMouseButtonDown(0)){  
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D rayhit = Physics2D.Raycast(mousePos, Vector2.zero);

                if (rayhit.collider != null && rayhit.transform == this.gameObject.transform){ //오브젝트를 클릭했을 때
                    
                    if(broken<=6){
                        if(!IsWait){
                            if(!IsCourtine) StartCoroutine(checktriple());
                            else {
                                IsClicked=true;
                            }
                        }
                    }else { //쓰레기통을 전부 부순 후
                        if(!IsWait&&!IsThrow){ 
                        IsThrow=true; //한번만 던지도록함
                        this.GetComponent<SETrigger>().SEtriggerfunc(4);
                        this.GetComponent<AnimTrigger>().goalanim();
                        }
                    }
                }
            }else IsClicked=false;
        }
    }

    IEnumerator checktriple(){ // 연속 3번 클릭했는지 체크하는 코루틴
        IsCourtine=true;
        currentTime=0;
        if(stack==0)    this.GetComponent<SETrigger>().SEtriggerfunc(1);

        while(currentTime<maxTime){
            currentTime+=Time.deltaTime;
            yield return null;
            if(IsClicked) { //연속 클릭한 경우
                Debug.Log("stack : "+stack);
                stack++; //스택 증가
                if(stack>=2){ //연속 3회 이상 클릭함
                    this.GetComponent<SETrigger>().SEtriggerfunc(3);
                    getBroken(); //함수 실행
                    stack=0; //다른 값 초기화
                    currentTime=0;
                    IsCourtine=false;
                    IsWait=true;
                    yield return new WaitForSeconds(0.1f);
                    IsWait=false;
                    IsClicked=false;
                    yield break; //코루틴을 종료
                }
                this.GetComponent<SETrigger>().SEtriggerfunc(2);
                currentTime=0;
                new WaitForSeconds(0.1f);
                yield return StartCoroutine(checktriple()); //한번 더 코루틴을 실행함
                yield break; //이후 코루틴 종료
            }

        }
        if(!IsThrow){
            IsThrow=true;
            this.GetComponent<AnimTrigger>().failanim();
        }
        stack=0;
        IsCourtine=false;
        IsClicked=false;
        yield break;
    }

    void getBroken(){
        broken++;
        if(broken<=6){
            this.GetComponent<AnimTrigger>().brokeanim(broken);
            this.GetComponent<SETrigger>().SEtriggerfunc(0);
        }else{
            this.GetComponent<AnimTrigger>().stopmoving();
            StartCoroutine(stopTrashcan());
        }
    }

    IEnumerator stopTrashcan(){ //쓰레기통을 모두 부순 후 실행할 코루틴
        IsWait=true;
        yield return new WaitForSeconds(1); //3초동안 정지
        IsWait=false;
    }

    public void finishthrow(){
        IsThrow=false;
    }
}
