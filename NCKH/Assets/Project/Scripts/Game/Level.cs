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

    public GameObject[] InteractableObj { get => _InteractableObj; set => _InteractableObj = value; }
    protected virtual void Start()
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
        UIController.instance.TutuarialText.text = _HintText;
        UIController.instance.SetSuccessPanel(false, _CorrectText);
        UIController.instance.HeadText.text = _HeadText;
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
        _Number.text = (int.Parse(_Number.text) + amout).ToString();
    }

    public virtual void ConfirmButton()
    {
        if (int.Parse(_Number.text) == _CorrectNumber)
        {
            LevelController.instance.LevelCorrect(new Vector3(0, 0));
        }
        else
        {
            LevelController.instance.LevelWrong(new Vector3(0, 0));
        }
    }

}
