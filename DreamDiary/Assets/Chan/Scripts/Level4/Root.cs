using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : Singleton<Root>
{
    public bool lv4 = false;
    public bool lv10 = false;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
