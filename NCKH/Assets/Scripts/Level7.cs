using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level7 : MonoBehaviour
{
    [SerializeField] GameObject dolphin;
    [SerializeField] GameObject crab;
    [SerializeField] GameObject snake;
    [SerializeField] GameObject turtle;

    [SerializeField] GameObject iconAccepted;
    [SerializeField] GameObject iconWrongAnswer;

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

    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerClick();
    }

    public void PlayerClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            Collider2D hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));
            if (hitCollider != null && hitCollider.CompareTag("turtle"))
            {
                Accepted();
            }
            else if (hitCollider != null)
            {
                WrongAnswer(hitCollider.transform.position);
            }

        }
    }

    public void Accepted()
    {
        //Debug.Log("Accepted");

        iconAccepted.SetActive(true);

        //StartCoroutine(ScaleIconAcepted());


    }
    public void WrongAnswer(Vector3 pos)
    {

        iconWrongAnswer.SetActive(true);

        iconWrongAnswer.transform.position = pos;

        //StartCoroutine(ScaleIconWrongAnswer());
    }
}
