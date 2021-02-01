using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : MonoBehaviour
{
    [SerializeField] GameObject buttonPlus;
    [SerializeField] GameObject buttonMinus;
    [SerializeField] GameObject buttonSubmit;
    [SerializeField] GameObject buttonClear;

    [SerializeField] GameObject iconAccepted;
    [SerializeField] GameObject iconWrongAnswer;
    [SerializeField] GameObject iconButtonTutorial;

    [SerializeField] GameObject panelFinish;
    [SerializeField] GameObject panelTutorial;

    [SerializeField] TextMesh textTutorial;

    [SerializeField] TextMesh answerText;

    private Vector3 scaleChange = new Vector3(.2f, .2f, 0f);
    private int answer;

    bool check = true;

    private void Start()
    {
        answerText.text = "0";
        answer = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            Collider2D hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));
            if (hitCollider != null && hitCollider.CompareTag("buttonplus"))
            {
                answer++;
                answer = Mathf.Min(99, answer);
                answerText.text = answer.ToString();
            }
            else if (hitCollider != null && hitCollider.CompareTag("buttonminus"))
            {
                answer--;
                answer = Mathf.Max(0, answer);
                answerText.text = answer.ToString();
            }
            else if (hitCollider != null && hitCollider.CompareTag("submitlevel4"))
            {
                if(answer == 14)
                {
                    Accepted();
                }
                else
                {
                    WrongAnswer();
                }
            }
            else if (hitCollider != null && hitCollider.CompareTag("clearlevel4"))
            {
                answer = 0;
                answerText.text = answer.ToString();
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
                answerText.fontSize = 0;
                answerText.characterSize = 0;
                if (FindObjectOfType<GameController>().numKey > 0)
                {
                    FindObjectOfType<GameController>().numKey--;
                    FindObjectOfType<GameController>().numKeyText.text = "Key: " + FindObjectOfType<GameController>().numKey.ToString();
                    textTutorial.text = "Tôi đếm được \n 14 hình tam giác \n còn bạn thì sao?";
                }
                else
                {
                    textTutorial.text = "Bạn không có chìa khóa \n để mở gợi ý";
                }
            }
            else if (hitCollider != null && hitCollider.CompareTag("buttonbacktutorial"))
            {
                iconButtonTutorial.SetActive(true);
                panelTutorial.SetActive(false);
                answerText.fontSize = 28;
                answerText.characterSize = 0.25f;
            }
        }
    }

    public void Accepted()
    {
        Debug.Log("Accepted");
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
        answerText.fontSize = 0;
        answerText.characterSize = 0;
    }

    public void WrongAnswer()
    {
        check = false;
        iconWrongAnswer.SetActive(true);
        //iconWrongAnswer.transform.position = pos;

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
    }
}
