using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMoveAndAnimateTrigger : MonoBehaviour
{

    public bool IsMeetReaper = false;
    public float movespeed;
    public GameObject reaper;

    Animator animator;
    Vector2 moveposition;
    Vector2 destination;
    float DistanceBetween;
    bool IsMoveable = true;
    bool IsAnimating = false;
    int ShadowCount = 0;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        destination = this.gameObject.transform.position;
    }
    void Update()
    {
        if (IsMoveable)
        {
            DistanceBetween = this.gameObject.transform.position.x - destination.x;
            if (DistanceBetween <= 0.1f && DistanceBetween >= -0.1f)
            {
                animator.SetBool("IsWalk", false);
            }
            else //고양이 걸어감
            {
                if (DistanceBetween >= 0.1f) //오브젝트 회전
                {
                    rotateLeft();
                }
                else
                {
                    rotateRight();
                }

                moveposition = Vector2.MoveTowards(this.gameObject.transform.position, destination, movespeed);
                this.gameObject.transform.position = moveposition;
            }

            if (Input.GetMouseButtonDown(1)) //오른쪽 마우스로 이동
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (mousePos.x >= -8 && mousePos.x <= 26)
                {
                    destination = new Vector2(mousePos.x, destination.y);
                    animator.SetBool("IsWalk", true);
                }
            }
        }else
        {
            animator.SetBool("IsWalk", false);
        }
    }

    public void rotateLeft()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    public void rotateRight()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsMeetReaper && collision.gameObject.name == "backmap")
        {
            IsMeetReaper = true;
            StartCoroutine(ReaperAndCatAnimTrigger());
        }else if(collision.gameObject.name == "endTrigger")
        {
            IsMoveable = false;
            FindObjectOfType<S6InGameManager>().endpuzzle();
        }
    }

    IEnumerator ReaperAndCatAnimTrigger()
    {
        IsMoveable = false;
        destination = this.gameObject.transform.position;

        reaper.SetActive(true);
        yield return new WaitForSeconds(1.3f);
        animator.SetBool("IsCut", true);
        yield return new WaitForSeconds(0.5f);
        reaper.SetActive(false);
    }

    public void AddShadow()
    {
        if (!IsAnimating)
        {
            StartCoroutine(AddShadowAnim());

            if (ShadowCount > 5)
            {
                animator.SetBool("IsCut", false);
                IsMoveable = true;
            }
        }
    }

    IEnumerator AddShadowAnim()
    {
        IsAnimating = true;
        ShadowCount++;
        animator.SetInteger("Shadows", ShadowCount);
        yield return new WaitForSeconds(0.5f);
        IsAnimating = false;
    }
}
