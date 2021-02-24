using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public static Level instance = null;
    [SerializeField] GameObject[] _InteractableObj = null;
    [SerializeField]
    protected string _HintText = "None";
    [SerializeField]
    protected string _CorrectText = "Well-done!!!";
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
    }
    public virtual void Correct(Vector3 pos)
    {
        UIController.instance.CorrectAnswer(pos);
    }
    public virtual void Wrong(Vector3 pos)
    {
        UIController.instance.WrongAnswer(pos);
    }

}
