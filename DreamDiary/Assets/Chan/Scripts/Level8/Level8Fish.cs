using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level8Fish : MonoBehaviour
{
    public bool isFinish = false;

    public void Finish()
    {
        if(isFinish)
        {
            SceneManager.LoadScene("Level10");
        }
    }
}
