using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToReattachedShadow : MonoBehaviour
{
    public CatMoveAndAnimateTrigger catstript;

    void Update()
    {
        if (catstript.IsMeetReaper)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D rayhit = Physics2D.Raycast(mousePos, Vector2.zero);
                if (rayhit.collider != null && rayhit.transform == this.gameObject.transform)
                {
                    GetAddShadow();
                }
            }
        }
    }
    

    void GetAddShadow()
    {
        catstript.AddShadow();
    }


}
