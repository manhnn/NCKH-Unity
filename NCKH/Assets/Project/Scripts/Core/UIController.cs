using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance = null;
    public delegate void Del(string message = "none");
    [Header("UI")]
    [SerializeField] TMP_Text _NumberkeyText;
    [SerializeField] TMP_Text _LevelText;

    [SerializeField] TMP_Text _HeadText = null;

    [SerializeField] GameObject _SuggestionIcon = null;
    [SerializeField] GameObject _TutuarialPanel = null;
    [SerializeField] TMP_Text _TutuarialText = null;
    [SerializeField] GameObject _LightFlash = null;

    [SerializeField] GameObject _SuccessPanel = null;
    [SerializeField] TMP_Text _SuccessText = null;

    [SerializeField] Animator _Animator = null;
    [SerializeField] GameObject _CorrectIcon = null;
    [SerializeField] GameObject _WrongIcon = null;

    bool _LevelCompleteFlag = false;

    public TMP_Text NumberkeyText { get => _NumberkeyText; set => _NumberkeyText = value; }
    public TMP_Text LevelText { get => _LevelText; set => _LevelText = value; }
    public GameObject SuggestionIcon { get => _SuggestionIcon; set => _SuggestionIcon = value; }
    public GameObject TutuarialPanel { get => _TutuarialPanel; set => _TutuarialPanel = value; }
    public TMP_Text TutuarialText { get => _TutuarialText; set => _TutuarialText = value; }
    public GameObject SuccessPanel { get => _SuccessPanel; set => _SuccessPanel = value; }
    public TMP_Text HeadText { get => _HeadText; set => _HeadText = value; }
    public TMP_Text SuccessText { get => _SuccessText; set => _SuccessText = value; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public void SetSuccessPanel(bool activeseft, string correct = "")
    {
        if (activeseft)
        {
            _LevelCompleteFlag = false;
            if (correct != "") SuccessText.text = correct;
            SuccessPanel.SetActive(true);
            if (LevelController.CurrentLevel == LevelController.ArchiedLevel)
                LevelController.instance.NumKey++;
        }
        else
            SuccessPanel.SetActive(false);
    }

    public void SetTutuarialPanel(bool activeseft)
    {
        if (activeseft)
        {
            SuggestionIcon.SetActive(false);
            TutuarialPanel.SetActive(true);
            if (LevelController.instance.NumKey > 0)
            {
                LevelController.instance.NumKey--;
                NumberkeyText.text = "Key: " + LevelController.instance.NumKey.ToString();
            }
            else
            {
                TutuarialText.text = "Bạn không có chìa khóa để mở gợi ý\nChơi màn mới để lấy chìa khóa";
            }
        }
        else
        {
            SuggestionIcon.SetActive(true);
            TutuarialPanel.SetActive(false);
        }
    }

    public void CorrectAnswer(Vector3 Pos, float sec = 0f)
    {
        if (!_LevelCompleteFlag)
        {
            AudioController.instance.PlayCorrectAudio();
            _CorrectIcon.transform.position = Pos;
            _Animator.SetTrigger("TriggerCorrect");
            SetWaitForSeconds(sec, CallbackForAnswer);
            _LevelCompleteFlag = true;
        }
    }
    void CallbackForAnswer(string message = "none")
    {
        SetSuccessPanel(true);
    }
    public void SetWaitForSeconds(float sec, Del callback)
    {
        StartCoroutine(WaitFewSecond(sec, callback));
    }
    IEnumerator WaitFewSecond(float sec, Del callback)
    {
        yield return new WaitForSeconds(sec);
        callback();
    }

    public void WrongAnswer(Vector3 Pos)
    {
        AudioController.instance.PlayWrongAudio();
        _WrongIcon.transform.position = Pos;
        _Animator.SetTrigger("TriggerWrong");
    }
}
