using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoInGameManager : MonoBehaviour
{
    public GameObject nullpanel;
    public GameObject manual;
    bool IsStart=false;
    bool IsManual=false;
    void Start()
    {
        manual.SetActive(false);
        StartCoroutine(ingameflow());
    }

    void Update()
    {
        if(IsStart&&!IsManual&&FindObjectOfType<DialogueManager>().inConversation==false) {
            startmanual();
        }
    }

    IEnumerator ingameflow(){ //게임 맨처음(페이드인, 화살표)
        nullpanel.GetComponent<FadeInOut>().fadein_func();
        yield return new WaitForSeconds(1);
        this.GetComponent<DialogueTrigger>().dialoguetrigger_func();
        IsStart=true;
        yield break;
    }

    public void startmanual(){
        StartCoroutine(manualflow());
    }

    IEnumerator manualflow(){
        IsManual=true;
        manual.SetActive(true);
        nullpanel.GetComponent<FadeInOut>().fadein_func();
        yield return new WaitForSeconds(3);
        this.GetComponent<SETrigger>().SEtriggerfunc(0); //효과음 실행
        nullpanel.GetComponent<FadeInOut>().fadeout_func();
        yield return new WaitForSeconds(2);
        this.GetComponent<ChangeScene>().nextScene();
    }

}
