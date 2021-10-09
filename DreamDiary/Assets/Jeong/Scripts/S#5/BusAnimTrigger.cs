using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusAnimTrigger : MonoBehaviour
{
    bool IsRide = false;
    public bool IsChange = false; //맵 바뀌어야할때
    public bool IsShadow = false; //그림자 생긴 후
    public int count = 0;
    Animator animator;

    public GameObject background;
    public GameObject secondmap;
    public GameObject finalback;

    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        if (!IsRide && Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D rayhit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (rayhit.collider != null && rayhit.transform == this.gameObject.transform)
            {
                if (count < 3)
                {
                    StartCoroutine(Getride());
                }
                else if (IsShadow)
                {
                    StartCoroutine(GetShadowRide());
                }
            }
        }
    }

    IEnumerator Getride()
    {
        IsRide = true;
        animator.SetBool("IsRide", true);
        yield return new WaitForSeconds(4f); //버스 탑승

        background.SetActive(false);
        animator.SetBool("IsRide", false);
        animator.SetBool("IsRun", true); 
        yield return new WaitForSeconds(2.5f); //달리는 버스
        count++;

        if (count >= 3)
        {
            secondmap.SetActive(true);
            yield return new WaitForSeconds(1); 

            animator.SetBool("IsRun", false); 
            
            yield return new WaitForSeconds(3);
            IsRide = false;
            animator.SetBool("IsGone", true);
            yield return new WaitForSeconds(1);
        }
        else
        {
            background.SetActive(true);
            yield return new WaitForSeconds(1); 

            animator.SetBool("IsRun", false); 
            yield return new WaitForSeconds(3); }

        IsRide = false;

    }

    public void Changeride()
    {
        StartCoroutine(GetChangeRide());
    }

    IEnumerator GetChangeRide()
    {
        animator.SetBool("IsGone", false);
        animator.SetBool("IsRun", true);
        secondmap.SetActive(false);
        yield return new WaitForSeconds(2.5f); //달리는 버스

        finalback.SetActive(true);
        yield return new WaitForSeconds(1); //버스 도착

        animator.SetBool("IsShadow", true);
        animator.SetBool("IsRun", false); //다른 맵에서 버스내리기
        yield return new WaitForSeconds(3.5f);
        IsRide = false;
        IsChange = false; //1번만 실행하기위함
        IsShadow = true; //그림자 생성
    }

    IEnumerator GetShadowRide()
    {
        IsRide = true;
        animator.SetBool("IsRide", true);
        yield return new WaitForSeconds(3.2f); //버스 탑승

        animator.SetBool("IsRide", false);
        animator.SetBool("IsRun", true);
        yield return new WaitForSeconds(1); //버스 출발

        finalback.SetActive(false);
        yield return new WaitForSeconds(3); //달리는 버스

        background.SetActive(true);
        yield return new WaitForSeconds(1f); //버스 도착

        animator.SetBool("IsShadow", true);
        animator.SetBool("IsRun", false); //버스내리기+그림자 없어지기
        yield return new WaitForSeconds(3.0f);
        IsRide = false;
        FindObjectOfType<S5InGameManager>().endpuzzle();
    }

}
