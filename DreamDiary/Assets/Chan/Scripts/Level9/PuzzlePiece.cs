using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    private const float distance = 0.1f;

    public int idx;

    private BoxCollider2D box2d;

    private Vector2 startPos;
    private Vector2 diff;

    private void Start()
    {
        startPos = transform.position;
        box2d = GetComponent<BoxCollider2D>();
    }

    private void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos + diff;

    }

    private void OnMouseDown()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        diff = (Vector2)transform.position - mousePos;
    }

    private void OnMouseUp()
    {
        if((Vector3.zero - transform.position).sqrMagnitude <= distance)
        {
            Level9Manager.instance.puzzle.PuzzleClear(idx);
            transform.position = Vector2.zero;
            box2d.enabled = false;
        }
        else
        {
            transform.position = startPos;
        }
    }
}
