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
    [Header("InGame")]
    [SerializeField] bool _Use = false;
    [SerializeField] float _TimeToChange = 2f;
    [Header("Scale")]
    [SerializeField] float _MaxScale = 2.5f;
    [SerializeField] float _MinScale = 0.5f;
    [SerializeField] float _TargetScale = 2.5f;
    float _CurrentScale = 1f;
    [Header("Move")]
    [SerializeField]
    bool _BackWhileMove = true;
    Vector3 _FirstScale = Vector3.zero;
    Vector3 _FirstPosition = Vector3.zero;
    LeanDragTranslate _DragTranlate = null;
    LeanPinchScale _PinchScale = null;
    LeanSelectable _Selectable = null;
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _DragTranlate = gameObject.AddComponent<LeanDragTranslate>();
        _DragTranlate.enabled = false;
        _PinchScale = gameObject.AddComponent<LeanPinchScale>();
        _PinchScale.enabled = false;
        _PinchScale.Sensitivity = 0.3f;
        _Selectable = gameObject.AddComponent<LeanSelectable>();
        _Selectable.DeselectOnUp = true;
        _FirstPosition = this.gameObject.transform.position;
        _FirstScale = this.transform.localScale;
        if ((_InterectType & InteractionType.Move) != 0)
        {
            SetUpForMove();
        }
        if ((_InterectType & InteractionType.Tap) != 0)
        {
            SetUpForTap();
        }
        if ((_InterectType & InteractionType.Scale) != 0)
        {
            SetUpForScale();
        }
        if ((_InterectType & InteractionType.Hold) != 0)
        {
            SetUpForHold();
        }
        if ((_InterectType & InteractionType.Swipe) != 0)
        {
            SetUpForSwipe();
        }
    }

    public void StopAllDOTween(LeanFinger leanFinger)
    {
        DOTween.Clear();
    }

    float time = 0;
    private void SetUpForMove()
    {
        _Selectable.OnSelect.AddListener(StopAllDOTween);
        _Selectable.OnSelect.AddListener(StartForMove);

        _Selectable.OnDeselect.AddListener(() =>
        {
            _DragTranlate.enabled = false;
            if (_BackWhileMove)
            {

                if (!_ScaleFlag && Use)
                    LevelController.instance.LevelCheck(true, this.transform.position, 1f);
                else if (!_ScaleFlag)
                    LevelController.instance.LevelCheck(false, this.transform.position);
                this.transform.DOMove(_FirstPosition, 0.5f);
            }
        });
    }
    private void StartForMove(LeanFinger leanFinger)
    {
        _DragTranlate.enabled = true;
    }

    void SetUpForTap()
    {
        _Selectable.OnSelect.AddListener(ListenerTapBegin);
    }
    void ListenerTapBegin(LeanFinger leanFinger)
    {
        if (Use)
        {
            Level.instance.Correct(this.transform.position);
        }
        else
        {
            Level.instance.Wrong(this.transform.position);
        }
    }

    bool _HoldFlag = false;
    void SetUpForHold()
    {
        _Selectable.OnSelect.AddListener(ListenerHoldBegin);
        _Selectable.OnSelectUpdate.AddListener(ListenerHoldInteract);
    }
    void ListenerHoldBegin(LeanFinger leanFinger)
    {
        time = 0;
        _HoldFlag = false;
    }
    void ListenerHoldInteract(LeanFinger leanFinger)
    {
        if (time > _TimeToChange && !_HoldFlag)
        {
            this.transform.localScale *= 2f;
            _HoldFlag = true;
        }
        else
        {
            time += Time.deltaTime;
        }
    }

    bool _ScaleFlag = false;

    public bool Use { get => _Use; set => _Use = value; }

    void SetUpForScale()
    {
        _Selectable.OnSelect.AddListener(ListenerScaleBegin);
        _Selectable.OnSelectUpdate.AddListener(ListenerScaleUpdate);
        _Selectable.OnSelectUp.AddListener(ListenerScaleUp);
    }
    void ListenerScaleBegin(LeanFinger leanFinger)
    {
        _PinchScale.enabled = true;
        _ScaleFlag = false;
    }
    void ListenerScaleUpdate(LeanFinger leanFinger)
    {
        if (!_ScaleFlag)
        {
            _CurrentScale = this.transform.localScale.magnitude / _FirstScale.magnitude;
        }
        if (_CurrentScale > _MaxScale)
            this.transform.localScale = _FirstScale * _MaxScale;
        if (_CurrentScale < _MinScale)
            this.transform.localScale = _FirstScale * _MinScale;
        if (Mathf.Abs(_CurrentScale - _TargetScale) <= 0.1f)
        {
            _ScaleFlag = true;
            _PinchScale.enabled = false;
            LevelController.instance.LevelCheck(true, this.transform.position, 1f);
        }
    }
    void ListenerScaleUp(LeanFinger leanFinger)
    {
        _PinchScale.enabled = false;
    }

    void SetUpForSwipe()
    { }
    //Update

}
