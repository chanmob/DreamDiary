using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasAnimTrigger : MonoBehaviour
{
    public bool IsTime=false;
    bool IsOn=false;
    Animator animator;
    void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsTime&&!IsOn&&Input.GetMouseButtonDown(0)){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D rayhit = Physics2D.Raycast(mousePos, Vector2.zero);
                if (rayhit.collider != null && rayhit.transform == this.gameObject.transform){ //가스 밸브 클릭하면
                    StartCoroutine(gasturnon());
                }
        }
    }

    IEnumerator gasturnon(){
        IsOn=true;
        animator.SetBool("IsOn",true);
        yield return new WaitForSeconds(1);
        this.GetComponent<SETrigger>().SEtriggerfunc(0);
        FindObjectOfType<PanAnimTrigger>().panonfire();
    }

}
