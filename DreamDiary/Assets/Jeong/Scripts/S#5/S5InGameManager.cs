using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S5InGameManager : MonoBehaviour
{
    public GameObject nullpanel;

    void Start()
    {
        StartCoroutine(ingameflow());
    }

    IEnumerator ingameflow()
    {   //���̵���
        nullpanel.GetComponent<FadeInOut>().fadein_func();
        yield return new WaitForSeconds(2);
    }


    public void endpuzzle()
    {
        StartCoroutine(endflow());
    }

    IEnumerator endflow()
    {
        nullpanel.GetComponent<FadeInOut>().fadeout_func();
        this.GetComponent<SETrigger>().SEtriggerfunc(0); //ȿ���� ����
        yield return new WaitForSeconds(2);
        this.GetComponent<ChangeScene>().nextScene();
    }
}
