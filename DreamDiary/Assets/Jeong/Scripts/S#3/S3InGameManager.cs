using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S3InGameManager : MonoBehaviour
{
    public GameObject nullpanel;
    public GameObject subway;
    Animator animator;
    void Start()
    {
        animator=subway.GetComponent<Animator>();
        StartCoroutine(ingameflow());
    }

    IEnumerator ingameflow(){ //페이드인
        nullpanel.GetComponent<FadeInOut>().fadein_func();
        yield return new WaitForSeconds(2);
        subway.GetComponent<SETrigger>().SEtriggerfunc(0);
        yield return new WaitForSeconds(2);
        animator.SetBool("IsStart",true);
        yield return new WaitForSeconds(2);
        animator.SetBool("IsNight",true);
        yield return new WaitForSeconds(2);
        animator.SetBool("IsNight",false);
        subway.GetComponent<SubwayAnimTrigger>().IsTime=true;
    }

    public void endpuzzle(){
        StartCoroutine(endflow());

    }

    IEnumerator endflow(){
        yield return new WaitForSeconds(2);
        nullpanel.GetComponent<FadeInOut>().fadeout_func();
        this.GetComponent<SETrigger>().SEtriggerfunc(0); //효과음 실행
        yield return new WaitForSeconds(2);
        this.GetComponent<ChangeScene>().nextScene();
    }
}
