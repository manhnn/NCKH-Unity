using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : Level
{
    bool check = true;

    protected override void Start()
    {
        base.Start();
        Init();
    }


    public void Init()
    {
        UIController.instance.TutuarialText.text = _HintText;
        List<Vector3> positions = new List<Vector3>();
        positions.Add(new Vector3(-1.2f, 1.5f, 0f));
        positions.Add(new Vector3(1.2f, 0f, 0f));
        positions.Add(new Vector3(-1.2f, -1.5f, 0f));
        positions.Add(new Vector3(1.2f, -3f, 0f));

        int rd = Random.Range(0, 3);


        InteractableObj[0].transform.position = positions[rd % positions.Count];
        InteractableObj[1].transform.position = positions[(rd + 1) % positions.Count];
        InteractableObj[2].transform.position = positions[(rd + 2) % positions.Count];
        InteractableObj[3].transform.position = positions[(rd + 3) % positions.Count];
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
