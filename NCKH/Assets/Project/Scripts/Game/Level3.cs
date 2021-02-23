using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    [SerializeField] GameObject box1;
    [SerializeField] GameObject box2;
    [SerializeField] GameObject box3;
    [SerializeField] GameObject box4;

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
            if (hitCollider != null && hitCollider.CompareTag("box2"))
            {
                Accepted();
            }
            else if (hitCollider != null && hitCollider.CompareTag("buttonNext"))
            {

                if (check == true)
                {
                    LevelController.instance.NumKey++;
                }
                FindObjectOfType<LevelController>().LoadNextLevel();
            }
            else if (hitCollider != null && hitCollider.CompareTag("buttontutorial"))
            {
                iconButtonTutorial.SetActive(false);
                panelTutorial.SetActive(true);
                if (LevelController.instance.NumKey > 0)
                {
                    LevelController.instance.NumKey--;
                    UIController.instance.NumberkeyText.text = "Key: " + LevelController.instance.NumKey.ToString();
                    textTutorial.text = "Bạn hãy nhìn thật kỹ \n các ống dẫn nước \n ở giữa các bình";
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
            }
            else if (hitCollider != null)
            {
                WrongAnswer(hitCollider.transform.position);
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
    }
}
