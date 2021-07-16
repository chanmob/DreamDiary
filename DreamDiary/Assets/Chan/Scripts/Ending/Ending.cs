using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    [TextArea]
    public List<string> goodDialoge = new List<string>();
    [TextArea]
    public List<string> normalDialoge = new List<string>();
    [TextArea]
    public List<string> badDialoge = new List<string>();

    [SerializeField]
    private Text _dialogMessage; // 메세지 텍스트

    public List<string> _dialogData = new List<string>();

    private int _dialogIdx = 0;
    private int _dialogCnt = 0;

    private IEnumerator showTextCoroutine;

    [Range(0.1f, 1f)]
    public float printDealy = 0.1f;

    [SerializeField]
    private bool _isPrinting = false;

    public string _currentMessage;

    private void Start()
    {
        SetDialogData();
    }

    public void SetDialogData()
    {
        if (Root.instance.lv10 == false && Root.instance.lv4 == false)
        {
            _dialogData = goodDialoge;
        }
        else if (Root.instance.lv10 == true && Root.instance.lv4 == true) 
        {
            _dialogData = badDialoge;
        }
        else
        {
            _dialogData = normalDialoge;
        }

        _dialogIdx = 0;
        _dialogCnt = _dialogData.Count;

        gameObject.SetActive(true);

        ShowNextDialog();
    }

    public void SkipDialog()
    {
        StopCoroutine(showTextCoroutine);
        _dialogMessage.text = _currentMessage;
        _isPrinting = false;
    }

    public void InteractOnDiglong()
    {
        if (_isPrinting)
            SkipDialog();
        else
            ShowNextDialog();
    }

    public void ShowNextDialog()
    {
        if (_dialogIdx < _dialogCnt)
        {
            _currentMessage = _dialogData[_dialogIdx];
            _dialogIdx++;

            showTextCoroutine = ShowTextCoroutine();
            StartCoroutine(showTextCoroutine);
        }

        else
        {
            gameObject.SetActive(false);
        }
    }

    public IEnumerator ShowTextCoroutine()
    {
        _isPrinting = true;

        _dialogMessage.text = string.Empty;

        WaitForSeconds wait = new WaitForSeconds(printDealy);

        for (var i = 0; i <= _currentMessage.Length; i++)
        {
            _dialogMessage.text = _currentMessage.Substring(0, i);
            yield return wait;
        }

        showTextCoroutine = null;

        _isPrinting = false;
    }


    public void DialogButtonPress()
    {
        if (_isPrinting)
        {
            StopCoroutine(showTextCoroutine);
            showTextCoroutine = null;

            _dialogMessage.text = _currentMessage;

            _isPrinting = false;
        }
        else
        {
            ShowNextDialog();
        }
    }
}
