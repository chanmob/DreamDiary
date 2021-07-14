using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public float FadeTime = 2f;
    Image fadeImg;
     float start;
    float end;
    float time = 0f;
    bool isPlaying = false;

    void Awake()
    {
        fadeImg = GetComponent<Image>();
    }
    public void fadeout_func() //점점 화면이 안보이는 페이드아웃
    {
        if(isPlaying) //중복재생방지
        {
            return;
        }

        start = 0f;
        end = 1f;
        StartCoroutine("fadeout");    //코루틴 실행
    }

public void fadein_func() //점점 화면이 보이는 페이드인
    {
        if (isPlaying) //중복재생방지
        {
            return;
        }
        start = 1f;
        end = 0f;
        StartCoroutine("fadein");
    }

    IEnumerator fadeout()
    {
        isPlaying = true;

        Color fadecolor = fadeImg.color;
        time = 0f;
        fadecolor.a = Mathf.Lerp(start, end, time);
        while (fadecolor .a < 0.9f)
        {
            time += Time.deltaTime / FadeTime;
            fadecolor.a = Mathf.Lerp(start, end, time);
            fadeImg.color = fadecolor;
            yield return null;
        }
        fadecolor.a=1f;
        fadeImg.color = fadecolor;
        isPlaying = false;
        yield break;
    }

    IEnumerator fadein() 
    {
        isPlaying = true;

        Color fadecolor = fadeImg.color;
        time = 0f;
        fadecolor.a = Mathf.Lerp(start, end, time);
        while (fadecolor .a > 0.1f)
        {
            time += Time.deltaTime / FadeTime;
            fadecolor.a = Mathf.Lerp(start, end, time);
            fadeImg.color = fadecolor;
            yield return null;
        }
        fadecolor.a=0f;
        fadeImg.color = fadecolor;
        isPlaying = false;
        yield break;
    }
}