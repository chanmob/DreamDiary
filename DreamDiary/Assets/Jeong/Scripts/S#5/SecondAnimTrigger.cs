using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondAnimTrigger : MonoBehaviour
{
    public GameObject cat;
    public GameObject bus;
    public GameObject parent;
    public GameObject crossbus;

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
        cat.GetComponent<Animator>().SetBool("IsCross", true);
        yield return new WaitForSeconds(1.3f);
        cat.SetActive(false);

        crossbus.GetComponent<Animator>().SetBool("IsGone", true);
        yield return new WaitForSeconds(1f);
        bus.GetComponent<BusAnimTrigger>().Changeride();
    }
}
