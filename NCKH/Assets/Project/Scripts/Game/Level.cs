using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    public static Level instance = null;
    [SerializeField] GameObject[] _InteractableObj = null;
    [SerializeField]
    protected string _HintText = "None";
    [SerializeField]
    protected string _CorrectText = "Well-done!!!";
    [SerializeField]
    protected string _HeadText = "Solve this";
    [Header("ForNumber")]
    [SerializeField] TMP_Text _Number = null;
    [SerializeField] int _CorrectNumber = -1;
    [Header("TapCount")]
    [SerializeField] protected Lean.Touch.LeanFingerTap LeanFingerTap = null;
    [SerializeField] protected int _TouchTapRequired = 2;
    [SerializeField] protected int _TouchCount = 0;

    public GameObject[] InteractableObj { get => _InteractableObj; set => _InteractableObj = value; }
    public TMP_Text Number { get => _Number; set => _Number = value; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
            instance = this;
        }
    }
    protected virtual void Start()
    {
        UIController.instance.TutuarialText.text = _HintText;
        UIController.instance.SuccessText.text = _CorrectText;
        UIController.instance.HeadText.text = _HeadText;
        LeanFingerTap = FindObjectOfType<Lean.Touch.LeanFingerTap>();
        LeanFingerTap.OnCount.AddListener(Condition);
    }

    public virtual void Correct(Vector3 pos)
    {
        UIController.instance.SetTutuarialPanel(false);
        UIController.instance.CorrectAnswer(pos, 1f);
    }
    public virtual void Wrong(Vector3 pos)
    {
        UIController.instance.WrongAnswer(pos);
    }

    public virtual void ChangeNumberButton(int amout)
    {
        int num = (int.Parse(Number.text) + amout);
        if (num <= 1e6 && num >= 0)
            Number.text = num.ToString();
    }

    public virtual void AddNumberButton(int amout)
    {
        int num = int.Parse(Number.text);
        num = num * 10 + amout;
        if (num <= 1e6 && num >= 0)
            Number.text = num.ToString();
    }

    public virtual void DeleteNumberButton()
    {
        int num = int.Parse(Number.text);
        num = num / 10;
        if (num <= 1e6 && num >= 0)
            Number.text = num.ToString();
    }

    public virtual void ClearNumberButton()
    {
        Number.text = "0";
    }

    public virtual void ConfirmButton()
    {
        if (int.Parse(Number.text) == _CorrectNumber)
        {
            LevelController.instance.LevelCorrect(new Vector3(0, 0));
        }
        else
        {
            LevelController.instance.LevelWrong(new Vector3(0, 0));
        }
    }

    public void Condition(int arg0)
    {
        _TouchCount = arg0;
        if (_TouchCount >= _TouchTapRequired)
            StartCoroutine(RetoreTap());

    }
    IEnumerator RetoreTap()
    {
        yield return new WaitForSeconds(0.2f);
        _TouchCount = 0;
    }

}
