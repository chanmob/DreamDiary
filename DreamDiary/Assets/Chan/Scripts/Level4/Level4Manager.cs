using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level4Manager : Singleton<Level4Manager>
{
    public Image fade;

    public Animator doorAnim;

    public GameObject idlePlayer;
    public Level4Player player;

    public GameObject leftDoor;
    public GameObject rightDoor;

    public GameObject idleMonster;
    public GameObject monster;

    public int doorCount = 0;

    public AudioClip doorclip;
    public AudioClip chaseclip;
    public AudioClip passclip;

    public AudioSource source;

    void Start()
    {
        StartCoroutine(FadeCoroutine());
        //StartCoroutine(StartCoroutine());
    }

    private IEnumerator FadeCoroutine()
    {
        float a = 1;

        while(fade.color.a > 0)
        {
            a -= Time.deltaTime * 0.5f;
            fade.color = new Color(0, 0, 0, a);
            yield return null;
        }

        fade.color = new Color(0, 0, 0, 0);
        fade.gameObject.SetActive(false);

        StartCoroutine(StartCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        source.clip = passclip;
        source.Play();

        player.canMove = false;
        fade.gameObject.SetActive(true);
        float a = 0;

        while (fade.color.a < 1)
        {
            a += Time.deltaTime * 0.5f;
            fade.color = new Color(0, 0, 0, a);
            yield return null;
        }

        fade.color = new Color(0, 0, 0, 1);
        SceneManager.LoadScene("Level8");
    }


    private IEnumerator StartCoroutine()
    {
        yield return new WaitForSeconds(2.5f);

        float vol = 0.3f;
        for(int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(2.5f);

            source.volume = vol;
            source.clip = doorclip;
            source.Play();
            vol += 0.15f;
        }

        idlePlayer.SetActive(false);
        player.gameObject.SetActive(true);
        doorAnim.SetTrigger("DoorOpen");
    }

    public void SpawnDoor(bool left)
    {
        //if(doorCount == 0)
        //{
        //    //source.loop = true;
        //    source.clip = chaseclip;
        //    source.Play();
        //}

        idleMonster.SetActive(false);
        monster.gameObject.SetActive(false);

        if (left)
        {
            monster.transform.position = rightDoor.transform.position;
            player.transform.position = new Vector2(rightDoor.transform.position.x - 1.5f, player.transform.position.y);
            doorCount--;
        }
        else
        {
            monster.transform.position = leftDoor.transform.position;
            player.transform.position = new Vector2(leftDoor.transform.position.x + 1.5f, player.transform.position.y);
            doorCount++;
        }

        if(Mathf.Abs(doorCount) >= 6)
        {
            StartCoroutine(FadeOutCoroutine());
            //SceneManager.LoadScene("Level8");
        }
        else
        {
            StartCoroutine(MonsterOn());
        }
    }

    public IEnumerator MonsterOn()
    {
        yield return new WaitForSeconds(1f);

        source.clip = chaseclip;
        source.Play();

        monster.gameObject.SetActive(true);
    }
}
