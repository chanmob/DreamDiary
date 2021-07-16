using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level10Manager : MonoBehaviour
{
    public Image fade;

    public AudioSource source;

    public AudioClip knockClip;
    public AudioClip windowClip;

    public Animator anim;

    private bool isWindowOpen = false;
    private bool isEnd = false;

    private bool canStart = false;

    private float checkTime = 0;

    private void Start()
    {
        StartCoroutine(FadeCoroutine());
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

        yield return new WaitForSeconds(7f);

        source.clip = knockClip;
        source.Play();

        yield return new WaitForSeconds(3f);

        source.clip = windowClip;
        source.Play();

        canStart = true;
    }

    private void Update()
    {
        if (isEnd)
            return;

        if (canStart)
        {
            if (isWindowOpen)
            {
                checkTime += Time.deltaTime;

                if (checkTime >= 10)
                {
                    isEnd = true;
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (!isWindowOpen)
                {
                    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

                    if (hit)
                    {
                        if (hit.collider.CompareTag("Level10Window"))
                        {
                            isWindowOpen = true;
                            anim.SetTrigger("Open");
                        }
                    }
                }
                else
                {
                    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

                    if (hit)
                    {
                        if (hit.collider.CompareTag("Level10Window"))
                        {
                            isEnd = true;
                            anim.SetTrigger("Fall");
                        }
                    }
                }
            }
        }

    }
}
