using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    [TextArea(3, 10)]
    public string[] Dialogue;
    void Start()
    {
        
    }

    public void dialoguetrigger_func(){
        FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
    }

}
