using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using DG.Tweening;
[System.Flags]
public enum InteractionType
{
    //Interaction by Tap Object
    Tap = 1,
    //Object can Drag
    Move = 2,
    //Object can scale
    Scale = 4,
    //Hold to Interact
    Hold = 8,
    //Swipe to interact
    Swipe = 16
}
public class InteractableObject : MonoBehaviour
{
    [SerializeField, EnumFlags] InteractionType _InterectType;
    Vector3 _FirstPosition = Vector3.zero;
    LeanDragTranslate _DragTranlate = null;
    LeanSelectable _Selectable = null;
    bool _HandSelected = true;
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _DragTranlate = gameObject.AddComponent<LeanDragTranslate>();
        _DragTranlate.enabled = false;
        _Selectable = gameObject.AddComponent<LeanSelectable>();
        _Selectable.DeselectOnUp = true;
        _FirstPosition = this.gameObject.transform.position;
        if ((_InterectType & InteractionType.Move) != 0)
            SetUpForMove();
        else
            //Thay doi thanh cac loai
            Debug.Log("TamThoi");
    }

    private void SetUpForMove()
    {
        _Selectable.OnSelect.AddListener(StopAllDOTween);
        _Selectable.OnDeselect.AddListener(() =>
        {
            this.transform.DOMove(_FirstPosition, 0.5f);
        });
        _HandSelected = false;
    }

    public void StopAllDOTween(LeanFinger leanFinger)
    {
        DOTween.Clear();
    }
    private void Update()
    {
        //Update For Move
        if ((_InterectType & InteractionType.Move) != 0)
        {
            if (_Selectable.IsSelected && !_HandSelected)
            {
                _DragTranlate.enabled = true;
                _HandSelected = true;
            }
            else if (!_Selectable.IsSelected && _HandSelected)
            {
                _DragTranlate.enabled = false;
                _HandSelected = false;
            }
        }
    }
}
