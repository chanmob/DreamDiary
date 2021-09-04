using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level7Manager : MonoBehaviour
{
    public GameObject skeleton;

    public GameObject map;

    public string nextStageName;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit)
            {
                if (hit.collider.name == "Skeleton")
                {
                    skeleton.SetActive(false);
                    map.SetActive(true);
                }
            }
        }
    }

    public void NextStage()
    {

    }
}
