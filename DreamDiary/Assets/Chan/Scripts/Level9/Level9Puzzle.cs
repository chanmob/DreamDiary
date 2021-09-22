using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level9Puzzle : MonoBehaviour
{
    public bool[] puzzleClear;

    public GameObject puzzleObj;
    public GameObject finish;

    public void PuzzleClear(int idx)
    {
        puzzleClear[idx] = true;

        if (CheckClear())
        {
            puzzleObj.SetActive(false);
            finish.SetActive(true);
            Level9Manager.instance.Finish();
        }
    }

    private bool CheckClear()
    {
        for (int i = 0; i < puzzleClear.Length; i++)
        {
            if (puzzleClear[i] == false)
                return false;
        }

        return true;
    }
}
