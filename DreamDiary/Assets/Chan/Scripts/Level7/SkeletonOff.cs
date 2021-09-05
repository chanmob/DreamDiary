using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonOff : MonoBehaviour
{
    public void End()
    {
        Level7Manager.instance.NextStage();
    }
}
