using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5 : Level
{
    [SerializeField] GameObject dolphin;
    [SerializeField] GameObject crab;
    [SerializeField] GameObject snake;
    [SerializeField] GameObject turtle;

    protected override void Start()
    {
        base.Start();
        Init();
    }

    public override void Correct(Vector3 pos)
    {
        base.Correct(pos);
    }
    public override void Wrong(Vector3 pos)
    {
        base.Wrong(pos);
    }
    public void Init()
    {
        List<Vector3> positions = new List<Vector3>();
        positions.Add(new Vector3(-1.2f, 1.5f, 0f));
        positions.Add(new Vector3(1.2f, 0f, 0f));
        positions.Add(new Vector3(-1.2f, -1.5f, 0f));
        positions.Add(new Vector3(1.2f, -3f, 0f));

        int rd = Random.Range(0, 3);

        dolphin.transform.position = positions[rd % positions.Count];
        crab.transform.position = positions[(rd + 1) % positions.Count];
        snake.transform.position = positions[(rd + 2) % positions.Count];
        turtle.transform.position = positions[(rd + 3) % positions.Count];
    }
}
