using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level7Map : MonoBehaviour
{
    private int headCount = 15;
    private int cutCount = 0;

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
                    cutCount++;

                    if(cutCount >= headCount)
                    {
                        MapClear();
                    }
                }
            }
        }
    }

    private void MapClear()
    {

    }
}
