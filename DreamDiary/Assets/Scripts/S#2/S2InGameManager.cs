using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2InGameManager : MonoBehaviour
{
    public GameObject nullpanel;
    public GameObject firstmap;
    public GameObject secondmap;
    int countchic=0; //병아리 개수 카운트

    void Start()
    {
        secondmap.SetActive(false);
        StartCoroutine(secondmapflow());
    }

    // Update is called once per frame
    IEnumerator firstmapflow(){ 
        nullpanel.GetComponent<FadeInOut>().fadein_func();
        yield return new WaitForSeconds(2);
    }

    public void nextpuzzle(){
        StartCoroutine(secondmapflow());
    }


    IEnumerator secondmapflow(){
        nullpanel.GetComponent<FadeInOut>().fadeout_func();
        yield return new WaitForSeconds(2);
        firstmap.SetActive(false);

        secondmap.SetActive(true);
        nullpanel.GetComponent<FadeInOut>().fadein_func();
        yield return new WaitForSeconds(2);
    }

    public void addchic(){
        countchic++;
    }
}
