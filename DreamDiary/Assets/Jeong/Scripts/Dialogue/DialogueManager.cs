using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueCanvas;
    public Text dialgoueText;
    public float typingSpeed;


    Queue<string> sentences; //대화 등록할 Queue

    string currentText;
    bool inTyping;
    public bool inConversation;
    IEnumerator corutine;

    void Start()
    {
        dialogueCanvas.SetActive(false);
        sentences = new Queue<string>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && inConversation)
        {
            if (inTyping)
            {
                StopCoroutine(corutine);
                dialgoueText.text = currentText;
                inTyping = false;
                return;
            }
            
            DisplayNextSentence();
        }
    }

    public void StartDialogue (string[] dialogue)
        {
            //이미 대화를 하고 있는 경우가 아니라면
            if (!inConversation)
            {
                //대사 시작 전 초기화
                sentences.Clear();

                //대사 전부 등록
                for (int i = 0; i < dialogue.Length; i++)
                {
                    sentences.Enqueue(dialogue[i]);
                }
                //대사 시작
                inConversation = true;
                if(dialogue.Length > 1) DisplayNextSentence();

            }
            dialogueCanvas.SetActive(true);

        }
        
    public void DisplayNextSentence()
        {
            if (sentences.Count == 0)
            {
                EndConversation();
                return;
            }

            //타이핑중이 아니라면
            if (!inTyping)
            {
                string sentence = sentences.Peek();

                dialgoueText.text = "";
                currentText = sentence;
                corutine = Type(sentence);
                StartCoroutine(corutine);

                sentences.Dequeue();
            }


        }

    public void EndConversation()
    {
        if(sentences.Count != 0) sentences.Dequeue();
        dialogueCanvas.SetActive(false); //대화창 퇴장
        inConversation = false;
    }

    //타이핑 효과
    IEnumerator Type(string sentence)
    {
        inTyping = true;
        foreach(char letter in sentence.ToCharArray())
        {
            dialgoueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        inTyping = false;
    }

}
