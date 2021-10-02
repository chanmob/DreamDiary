using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusAnimTrigger : MonoBehaviour
{
    bool IsRide = false;
    public bool IsChange = false; //�� �ٲ����Ҷ�
    public bool IsShadow = false; //�׸��� ���� ��
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
                else if (IsChange)
                {
                    StartCoroutine(GetChangeRide());
                }else if (IsShadow)
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
        yield return new WaitForSeconds(3); //���� ž��

        animator.SetBool("IsRide", false);
        animator.SetBool("IsRun", true); 
        yield return new WaitForSeconds(1); //���� ���

        background.SetActive(false);
        yield return new WaitForSeconds(3); //�޸��� ����

        background.SetActive(true);
        yield return new WaitForSeconds(1); //���� ����

        animator.SetBool("IsRun", false); //�������� ������
        count++;
        if (count >= 3)
        {
            secondmap.SetActive(true);
            yield return new WaitForSeconds(3);
            IsRide = false;
            animator.SetBool("IsGone", true);
        }
        else { yield return new WaitForSeconds(3); }
        IsRide = false;

    }

    public void Changeride()
    {
        StartCoroutine(GetChangeRide());
    }

    IEnumerator GetChangeRide()
    {
        IsRide = true;
        animator.SetBool("IsRide", true);
        yield return new WaitForSeconds(3); //���� ž��

        animator.SetBool("IsRide", false);
        animator.SetBool("IsRun", true);
        yield return new WaitForSeconds(1); //���� ���

        background.SetActive(false);
        yield return new WaitForSeconds(3); //�޸��� ����

        finalback.SetActive(true);
        yield return new WaitForSeconds(1); //���� ����

        animator.SetBool("IsShadow", true);
        animator.SetBool("IsRun", false); //�ٸ� �ʿ��� ����������
        yield return new WaitForSeconds(3);
        IsRide = false;
        IsChange = false; //1���� �����ϱ�����
        IsShadow = true; //�׸��� ����
    }

    IEnumerator GetShadowRide()
    {
        IsRide = true;
        animator.SetBool("IsRide", true);
        yield return new WaitForSeconds(3); //���� ž��

        animator.SetBool("IsRide", false);
        animator.SetBool("IsRun", true);
        yield return new WaitForSeconds(1); //���� ���

        finalback.SetActive(false);
        yield return new WaitForSeconds(3); //�޸��� ����

        background.SetActive(true);
        yield return new WaitForSeconds(1); //���� ����

        animator.SetBool("IsShadow", true);
        animator.SetBool("IsRun", false); //����������+�׸��� ��������
        yield return new WaitForSeconds(3);
        IsRide = false;
        FindObjectOfType<S5InGameManager>().endpuzzle();
    }

}
