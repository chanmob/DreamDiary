using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2InGameManager : MonoBehaviour
{
    public GameObject nullpanel;
    public GameObject firstmap;
    public GameObject secondmap;
    public GameObject arrow;
    GameObject[] chickens;
    int countchic=0; //병아리 개수 카운트

    void Start()
    {
        chickens=GameObject.FindGameObjectsWithTag("Chicken");
        secondmap.SetActive(false);
        StartCoroutine(firstmapflow());
    }

    // Update is called once per frame
    IEnumerator firstmapflow(){ 
        nullpanel.GetComponent<FadeInOut>().fadein_func();
        yield return new WaitForSeconds(3);
    }

    public void nextpuzzle(){
        StartCoroutine(secondmapflow());
    }


    IEnumerator secondmapflow(){
        nullpanel.GetComponent<FadeInOut>().fadeout_func();
        yield return new WaitForSeconds(4);
        firstmap.SetActive(false);

        secondmap.SetActive(true);
        for(int i=0;i<chickens.Length;i++){
            chickens[i].SetActive(false);
        }
        arrow.SetActive(false);
        nullpanel.GetComponent<FadeInOut>().fadein_func();
        yield return new WaitForSeconds(3);
    }

    public void showchicken(){
        for(int i=0;i<chickens.Length;i++){
            chickens[i].SetActive(true);
            chickens[i].GetComponent<ChickenMoving>().IsStart=true;
        }
    }

    public void addchic(){
        countchic++;
        if(countchic>=6){
            turnongas();
        }
    }

    public void turnongas(){
        StartCoroutine(showgashere());
    }

    IEnumerator showgashere(){
        arrow.SetActive(true);
        arrow.GetComponent<Animator>().SetBool("IsShow",true);
        FindObjectOfType<GasAnimTrigger>().IsTime=true;
        yield return new WaitForSeconds(2);
        arrow.GetComponent<Animator>().SetBool("IsShow",false);
        arrow.SetActive(false);
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
