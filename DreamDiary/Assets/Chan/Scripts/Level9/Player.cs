using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void End()
    {
        Level9Manager.instance.AnimFinish();
    }
}
