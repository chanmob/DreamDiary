using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    public GameObject nullpanel;
    public GameObject successpanel;
    public GameObject arrow;
    public GameObject throwit;
    public bool isstart=false;
    Color blankcolor;
    void Start()
    {
        blankcolor=successpanel.GetComponent<Image>().color;
        throwit.SetActive(false);
        blankcolor.a=0f;
        successpanel.GetComponent<Image>().color=blankcolor;

        isstart=true;
        StartCoroutine(ingameflow());
    }

    public void endgame(){
        StartCoroutine(endflow());
    }

    IEnumerator ingameflow(){ //게임 맨처음(페이드인, 화살표)
        nullpanel.GetComponent<FadeInOut>().fadein_func();
        yield return new WaitForSeconds(3);
        arrow.GetComponent<Animator>().SetBool("IsNext",true);
        yield return new WaitForSeconds(2);
        arrow.GetComponent<Animator>().SetBool("IsFade",true);
        throwit.SetActive(true);
        yield return new WaitForSeconds(2);
        throwit.SetActive(false);
        isstart=false;
        yield break;
    }

    IEnumerator endflow(){
        successpanel.GetComponent<FadeInOut>().fadeout_func();
        yield return new WaitForSeconds(1);
    }
    
}
