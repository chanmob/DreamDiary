using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level8Manager : MonoBehaviour
{
    public bool isFeed;

    public GameObject anim;
    public GameObject idleFeed;

    public Image fade;

    public GameObject firstFeed;
    public GameObject secondFeed;

    public GameObject firstFish;
    public GameObject secondFish;

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
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isFeed)
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

                if (hit)
                {
                    if (hit.collider.CompareTag("Level8Feed"))
                    {
                        isFeed = true;
                    }
                }
            }
            else
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

                if (hit)
                {
                    if (hit.collider.CompareTag("Level8FishTank"))
                    {
                        idleFeed.gameObject.SetActive(false);
                        anim.gameObject.SetActive(true);
                    }
                }
            }
        }
    }
}
