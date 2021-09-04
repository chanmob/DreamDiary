using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level7Manager : MonoBehaviour
{
    public GameObject skeleton;

    public GameObject map;

    public string nextStageName;

    public Image fade;

    private void Start()
    {
        StartCoroutine(FadeCoroutine());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit)
            {
                if (hit.collider.name == "Skeleton")
                {
                    skeleton.SetActive(false);
                    map.SetActive(true);
                }
            }
        }
    }

    public void NextStage()
    {

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
        fade.gameObject.SetActive(true);

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
