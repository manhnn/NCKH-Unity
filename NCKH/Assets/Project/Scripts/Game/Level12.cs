﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level12 : Level
{

    protected override void Start()
    {
        base.Start();
    }

    public override void Correct(Vector3 pos)
    {
        base.Correct(pos);
    }
    public override void Wrong(Vector3 pos)
    {
        base.Wrong(pos);
    }

    public void TapCount()
    {
        if (_TouchCount >= _TouchTapRequired - 1)
        {
            UIController.instance.SetSuccessPanel(true);
        }
    }

}
