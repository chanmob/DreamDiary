using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondAnimTrigger : MonoBehaviour
{
    public Animator cat_animator; //cat 애니메이터
    public GameObject bus;
    public GameObject parent;
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D rayhit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (rayhit.collider != null && rayhit.transform == this.gameObject.transform)
            {
                StartCoroutine(CrossCat());
            }
        }
    }

    IEnumerator CrossCat()
    {
        cat_animator.SetBool("IsCross", true);
        yield return new WaitForSeconds(1.3f);
        bus.GetComponent<Animator>().SetBool("IsGone", false);
        bus.GetComponent<BusAnimTrigger>().IsChange=true;
        parent.SetActive(false);
    }
}
