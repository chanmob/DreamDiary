using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level8Manager : Singleton<Level8Manager>
{
    public bool isFeed;

    public GameObject anim;
    public GameObject idleFeed;

    public Image fade;

    public GameObject firstFeed;
    public GameObject secondFeed;

    public GameObject firstFish;
    public GameObject secondFish;

    private bool isEnd = false;

    public AudioSource source;

    public AudioClip eatClip;
    public AudioClip feedClip;
    public AudioClip passClip;

    public void EatSound()
    {
        source.PlayOneShot(eatClip);
    }

    public void FeedSound()
    {
        source.PlayOneShot(feedClip);
    }

    private void Start()
    {
        StartCoroutine(FadeCoroutine());
    }

    public void End()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        source.clip = passClip;
        source.Play();

        fade.gameObject.SetActive(true);
        float a = 0;

        while (fade.color.a < 1)
        {
            a += Time.deltaTime * 0.5f;
            fade.color = new Color(0, 0, 0, a);
            yield return null;
        }

        fade.color = new Color(0, 0, 0, 1);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level9");
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

    private Vector2 offset;

    private void Update()
    {
        if (isEnd)
            return;

        if (isFeed)
            idleFeed.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;

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
                        offset = (Vector2)idleFeed.transform.position - mousePos;
                        idleFeed.GetComponent<BoxCollider2D>().enabled = false;
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
                        isEnd = true;
                    }
                }
            }
        }
    }
}
