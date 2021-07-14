using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCatch : MonoBehaviour
{
    bool IsMove=false;
    void Start()
    {
        
    }
    void Update()
    {
        if(!IsMove&&Input.GetMouseButtonDown(0)){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D rayhit = Physics2D.Raycast(mousePos, Vector2.zero);
                if (rayhit.collider != null && rayhit.transform == this.gameObject.transform){
                    IsMove=true;
                    this.GetComponent<ChickenMoving>().IsStop=true;
                }
        }
        if(IsMove&&Input.GetMouseButton(0)){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position=new Vector2(mousePos.x,mousePos.y);
        }
        if(IsMove&&Input.GetMouseButtonUp(0)){
            IsMove=false;
            this.GetComponent<ChickenMoving>().endmoving();
            this.GetComponent<ChickenMoving>().IsStop=false;
        }
    }
}
