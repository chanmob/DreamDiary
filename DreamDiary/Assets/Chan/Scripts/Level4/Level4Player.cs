using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Player : MonoBehaviour
{
    public bool canMove = false;

    private Animator anim;

    public float playerSpeed = 1f;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!canMove)
            return;

        if (Input.GetMouseButton(0))
        { 
            Vector3 mousePos = Input.mousePosition;
            Vector3 toWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

            if (toWorldPos.x > transform.position.x + 0.3f)
            {
                transform.Translate(Vector2.right * playerSpeed * Time.deltaTime);
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.Translate(Vector2.left * playerSpeed * Time.deltaTime);
                transform.localScale = Vector3.one;
            }
        }
    }

    public void CanMove()
    {
        canMove = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Level4Door"))
        {
            Level4Manager.instance.SpawnDoor(true);
        }
        else if (collision.CompareTag("Level4Door2"))
        {
            Level4Manager.instance.SpawnDoor(false);
        }
        else if (collision.CompareTag("Level4Monster"))
        {

        }
    }
}
