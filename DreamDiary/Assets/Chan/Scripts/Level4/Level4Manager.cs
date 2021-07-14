using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    void Start()
    {
        StartCoroutine(FadeCoroutine());
        StartCoroutine(StartCoroutine());
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
    }

    private IEnumerator StartCoroutine()
    {
        yield return new WaitForSeconds(5f);

        idlePlayer.SetActive(false);
        player.gameObject.SetActive(true);
        doorAnim.SetTrigger("DoorOpen");
    }

    public void SpawnDoor(bool left)
    {
        idleMonster.SetActive(false);
        monster.gameObject.SetActive(false);

        if (left)
        {
            monster.transform.position = rightDoor.transform.position;
            player.transform.position = new Vector2(rightDoor.transform.position.x - 1.5f, player.transform.position.y);
        }
        else
        {
            monster.transform.position = leftDoor.transform.position;
            player.transform.position = new Vector2(leftDoor.transform.position.x + 1.5f, player.transform.position.y);
        }

        StartCoroutine(MonsterOn());
    }

    public IEnumerator MonsterOn()
    {
        yield return new WaitForSeconds(1f);

        monster.gameObject.SetActive(true);
    }
}
