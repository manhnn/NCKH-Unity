using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : Level
{
    [SerializeField] GameObject sun;
    [SerializeField] GameObject chicken;
    [SerializeField] GameObject cow;
    [SerializeField] GameObject dog;
    [SerializeField] GameObject pig;


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

        chicken.transform.position = positions[rd % positions.Count];
        cow.transform.position = positions[(rd + 1) % positions.Count];
        dog.transform.position = positions[(rd + 2) % positions.Count];
        pig.transform.position = positions[(rd + 3) % positions.Count];

        sun.transform.position = new Vector3(1.85f, 3f, 0f);
    }

}
