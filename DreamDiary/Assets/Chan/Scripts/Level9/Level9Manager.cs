using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level9Manager : Singleton<Level9Manager>
{
    public Image fade;

    public Level9Puzzle puzzle;

    private void Start()
    {
        StartCoroutine(FadeCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        fade.gameObject.SetActive(true);
        float a = 0;

        while (fade.color.a < 1)
        {
            a += Time.deltaTime * 0.5f;
            fade.color = new Color(0, 0, 0, a);
            yield return null;
        }

        fade.color = new Color(0, 0, 0, 1);
    }

    private IEnumerator FadeCoroutine()
    {
        float a = 1;

        while (fade.color.a > 0)
        {
            a -= Time.deltaTime * 0.5f;
            fade.color = new Color(0, 0, 0, a);
            yield return null;
        }

        fade.color = new Color(0, 0, 0, 0);
        fade.gameObject.SetActive(false);
    }
}
