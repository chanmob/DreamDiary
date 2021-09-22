using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level9Manager : Singleton<Level9Manager>
{
    public Image fade;

    public Level9Puzzle puzzle;

    public bool isAnim = true;

    public Animator anim;

    public int count;

    public GameObject arrow;

    public GameObject puzzleObj;
    public GameObject idleObj;

    public string nextScene;

    private void Start()
    {
        StartCoroutine(FadeCoroutine());
        StartCoroutine(ShowArrow());
    }

    private IEnumerator ShowArrow()
    {
        yield return new WaitForSeconds(3f);

        arrow.gameObject.SetActive(true);
        isAnim = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAnim)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit)
            {
                if (hit.collider.CompareTag("Puzzle"))
                {
                    isAnim = true;
                    anim.SetTrigger("Eat");
                    hit.collider.gameObject.SetActive(false);
                    count++;
                }
            }
        }
    }

    public void AnimFinish()
    {
        isAnim = false;

        if(count >= 5)
        {
            arrow.gameObject.SetActive(false);
            idleObj.gameObject.SetActive(false);
            puzzle.gameObject.SetActive(true);
        }
    }

    public void Finish()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        yield return new WaitForSeconds(2f);
            
        fade.gameObject.SetActive(true);
        float a = 0;

        while (fade.color.a < 1)
        {
            a += Time.deltaTime * 0.5f;
            fade.color = new Color(0, 0, 0, a);
            yield return null;
        }

        fade.color = new Color(0, 0, 0, 1);
        SceneManager.LoadScene(nextScene);
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
