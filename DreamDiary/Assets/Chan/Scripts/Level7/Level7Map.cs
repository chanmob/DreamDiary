using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level7Map : MonoBehaviour
{
    public GameObject headParent;

    public GameObject map;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit)
            {
                if (hit.collider.name == "SkeletonHead")
                {
                    hit.collider.gameObject.SetActive(false);

                    if (CheckClaer())
                    {
                        MapClear();
                    }
                }
            }
        }
    }

    private void MapClear()
    {
        map.SetActive(true);
        gameObject.SetActive(false);
    }

    private bool CheckClaer()
    {
        for(int i = 0; i < headParent.transform.childCount; i++)
        {
            if (headParent.transform.GetChild(i).gameObject.activeSelf)
            {
                return false;
            }
        }

        return true;
    }
}
