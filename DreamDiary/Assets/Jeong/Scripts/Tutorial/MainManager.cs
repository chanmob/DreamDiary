using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public GameObject nullpanel;
    public GameObject mainpanel;
    public GameObject introimg;
    void Start()
    {
        mainpanel.SetActive(false);
        introimg.SetActive(false);
        StartCoroutine(mainflow());
    }

    IEnumerator mainflow(){
        yield return new WaitForSeconds(1);
        nullpanel.GetComponent<FadeInOut>().fadein_func();
        yield return new WaitForSeconds(1);
        introimg.SetActive(true);
        introimg.GetComponent<Animator>().SetBool("IsMoving",true);
        yield return new WaitForSeconds(8);
        nullpanel.GetComponent<FadeInOut>().fadeout_func();
        yield return new WaitForSeconds(3);
        mainpanel.SetActive(true);
        nullpanel.GetComponent<FadeInOut>().fadein_func();
        yield return new WaitForSeconds(2);
        nullpanel.SetActive(false);
    }


}
