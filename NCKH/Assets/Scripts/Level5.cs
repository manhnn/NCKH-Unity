using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5 : MonoBehaviour
{
    [SerializeField] GameObject num1;
    [SerializeField] GameObject num2;
    [SerializeField] GameObject num6;
    [SerializeField] GameObject num8;
    [SerializeField] GameObject num17;
    [SerializeField] GameObject num20;
    [SerializeField] GameObject num60;

    [SerializeField] GameObject iconAccepted;
    [SerializeField] GameObject iconWrongAnswer;
    [SerializeField] GameObject iconButtonTutorial;

    [SerializeField] GameObject panelFinish;
    [SerializeField] GameObject panelTutorial;

    [SerializeField] TextMesh textTutorial;
    [SerializeField] TextMesh textHeader;

    Vector3 scaleChange = new Vector3(.2f, .2f, 0f);

    bool check = true;

    List<int> ans = new List<int>();

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
        List<Vector3> posTemps = new List<Vector3>();
        List<Vector3> positions = new List<Vector3>();
        posTemps.Add(new Vector3(-0.6f, 1.5f, 0f));
        posTemps.Add(new Vector3(1.2f, 1.2f, 0f));
        posTemps.Add(new Vector3(-1.6f, -0.3f, 0f));
        posTemps.Add(new Vector3(0.1f, -0.8f, 0f));
        posTemps.Add(new Vector3(1.6f, -0.6f, 0f));
        posTemps.Add(new Vector3(-1.25f, -2.15f, 0f));
        posTemps.Add(new Vector3(1.15f, -2.45f, 0f));

        int n = 7; 
        while(n > 0)
        {
            int rd = Random.Range(0, n - 1);
            positions.Add(posTemps[rd]);
            posTemps[rd] = posTemps[n - 1];
            n--;
        }

        num1.transform.position = positions[0];
        num2.transform.position = positions[1];
        num6.transform.position = positions[2];
        num8.transform.position = positions[3];
        num17.transform.position = positions[4];
        num20.transform.position = positions[5];
        num60.transform.position = positions[6];

        ans.Add(17);
        ans.Add(2);
        ans.Add(20);
        ans.Add(60);
        ans.Add(6);
        ans.Add(1);
        ans.Add(8);
    }

    public void PlayerClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            Collider2D hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));
            if (hitCollider != null && hitCollider.CompareTag("num1"))
            {
                if(ans[0] == 1)
                {
                    ans.Remove(1);
                    num1.SetActive(false);
                }
                else
                {
                    WrongAnswer(hitCollider.transform.position);
                }
                
            }
            else if (hitCollider != null && hitCollider.CompareTag("num2"))
            {
                if (ans[0] == 2)
                {
                    ans.Remove(2);
                    num2.SetActive(false);
                }
                else
                {
                    WrongAnswer(hitCollider.transform.position);
                }
            }
            else if (hitCollider != null && hitCollider.CompareTag("num6"))
            {
                if (ans[0] == 6)
                {
                    ans.Remove(6);
                    num6.SetActive(false);
                }
                else
                {
                    WrongAnswer(hitCollider.transform.position);
                }
            }
            else if (hitCollider != null && hitCollider.CompareTag("num8"))
            {
                if (ans[0] == 8)
                {
                    ans.Remove(8);
                    num8.SetActive(false);
                }
                else
                {
                    WrongAnswer(hitCollider.transform.position);
                }
            }
            else if (hitCollider != null && hitCollider.CompareTag("num17"))
            {
                if (ans[0] == 17)
                {
                    ans.Remove(17);
                    num17.SetActive(false);
                    textHeader.text = "Nhân các số theo thứ tự: \n ..., ..., ..., ..., ..., ..., ...";
                }
                else
                {
                    WrongAnswer(hitCollider.transform.position);
                }
            }
            else if (hitCollider != null && hitCollider.CompareTag("num20"))
            {
                if (ans[0] == 20)
                {
                    ans.Remove(20);
                    num20.SetActive(false);
                }
                else
                {
                    WrongAnswer(hitCollider.transform.position);
                }

            }
            else if (hitCollider != null && hitCollider.CompareTag("num60"))
            {
                if (ans[0] == 60)
                {
                    ans.Remove(60);
                    num60.SetActive(false);
                }
                else
                {
                    WrongAnswer(hitCollider.transform.position);
                }
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
                    textTutorial.text = "Để tôi nhắc lại nhé: \n 17, 2, 20, 60, 6, 1, 8. \n Bạn hãy nhớ thật kỹ.";
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
            //else if (hitCollider != null)
            //{
            //    WrongAnswer(hitCollider.transform.position);
            //}

        }
        if(ans.Count == 0)
        {
            Accepted();
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
        FindObjectOfType<GameController>().DestroyGameObj();
        FindObjectOfType<GameController>().NewTurn();
        ///vi load lai file check n se reset mat nen numKey sai
    }
}
