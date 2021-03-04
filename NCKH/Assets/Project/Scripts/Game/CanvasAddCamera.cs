using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAddCamera : MonoBehaviour
{
    [SerializeField] Canvas canvas = null;
    void Start()
    {
        canvas.worldCamera = Camera.main;
        canvas.sortingLayerName = "Front";
    }

}
