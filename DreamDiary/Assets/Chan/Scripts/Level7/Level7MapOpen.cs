using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level7MapOpen : MonoBehaviour
{
    public GameObject mapWithHands;


    public void MapWithHandsOn()
    {
        mapWithHands.SetActive(true);
        gameObject.SetActive(false);
    }

}
