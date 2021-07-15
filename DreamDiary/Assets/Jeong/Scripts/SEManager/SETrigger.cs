using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SETrigger : MonoBehaviour
{
    public AudioClip[] SEgroup;

    public void SEtriggerfunc(int i){
        FindObjectOfType<SEManager>().SEplay(SEgroup[i]);
    }
    public void SEStopfunc(){
        FindObjectOfType<SEManager>().SEStop();
    }
}
