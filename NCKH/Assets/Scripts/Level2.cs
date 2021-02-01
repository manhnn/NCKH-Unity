using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    [SerializeField] GameObject sun;
    [SerializeField] GameObject chicken;
    [SerializeField] GameObject cow;
    [SerializeField] GameObject dog;
    [SerializeField] GameObject pig;

    [SerializeField] GameObject iconAccepted;
    [SerializeField] GameObject iconWrongAnswer;
    [SerializeField] GameObject iconButtonTutorial;

    [SerializeField] GameObject panelFinish;
    [SerializeField] GameObject panelTutorial;

    [SerializeField] TextMesh textTutorial;

    Vector3 scaleChange = new Vector3(.2f, .2f, 0f);

    bool check = true;

    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerClick();
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

    public void PlayerClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            Collider2D hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));
            if (hitCollider != null && hitCollider.CompareTag("sun"))
            {
                Accepted();
            }
            else if (hitCollider != null && hitCollider.CompareTag("buttonNext"))
            {

                FindObjectOfType<GameController>().DestroyGameObj();

                FindObjectOfType<GameController>().level++;

                if (check == true)
                {
                    FindObjectOfType<GameController>().numKey++;
                }
                FindObjectOfType<GameController>().NewTurn();
            }
            else if (hitCollider != null && hitCollider.CompareTag("buttontutorial"))
            {
                iconButtonTutorial.SetActive(false);
                panelTutorial.SetActive(true);
                if (FindObjectOfType<GameController>().numKey > 0)
                {
                    FindObjectOfType<GameController>().numKey--;
                    FindObjectOfType<GameController>().numKeyText.text = "Key: " + FindObjectOfType<GameController>().numKey.ToString();
                    textTutorial.text = "Mặt trời luôn luôn \n ở trên cao nhất rồi!";
                }
                else
                {
                    textTutorial.text = "Bạn không có chìa khóa \n để mở gợi ý";
                }
            }
            else if (hitCollider != null && hitCollider.CompareTag("buttonbacktutorial"))
            {
                panelTutorial.SetActive(false);
                iconButtonTutorial.SetActive(true);
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

        StartCoroutine(ScaleIconAcepted());
    }
    IEnumerator ScaleIconAcepted()
    {
        while (iconAccepted.transform.localScale.x < 3f && iconAccepted.transform.localScale.y < 3f)
        {
            iconAccepted.transform.localScale += scaleChange;
            yield return null;
        }
        yield return new WaitForSeconds(1f);


        panelFinish.SetActive(true);
    }

    public void WrongAnswer(Vector3 pos)
    {
        check = false;
        iconWrongAnswer.SetActive(true);
        iconWrongAnswer.transform.position = pos;

        StartCoroutine(ScaleIconWrongAnswer());
    }

    IEnumerator ScaleIconWrongAnswer()
    {
        while (iconWrongAnswer.transform.localScale.x < 3f && iconWrongAnswer.transform.localScale.y < 3f)
        {
            iconWrongAnswer.transform.localScale += scaleChange;
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        while (iconWrongAnswer.transform.localScale.x > 0.1f && iconWrongAnswer.transform.localScale.y > 0.1f)
        {
            iconWrongAnswer.transform.localScale -= scaleChange;
            yield return null;
        }
        yield return null;

        iconWrongAnswer.SetActive(false);
        //FindObjectOfType<GameController>().DestroyGameObj();
        //FindObjectOfType<GameController>().NewTurn();
    }
}
