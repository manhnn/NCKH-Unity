using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : Level
{
    [SerializeField] GameObject box1;
    [SerializeField] GameObject box2;
    [SerializeField] GameObject box3;
    [SerializeField] GameObject box4;

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
}
