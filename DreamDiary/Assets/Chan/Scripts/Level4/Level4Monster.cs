using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Monster : MonoBehaviour
{
    public GameObject player;

    public float speed;

    private void FixedUpdate()
    {
        if(player.transform.position.x > transform.position.x)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
}
