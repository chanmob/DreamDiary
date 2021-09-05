using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapClose : MonoBehaviour
{
    public GameObject up;

    public void OnUp()
    {
        up.SetActive(true);
        gameObject.SetActive(false);
    }
}
