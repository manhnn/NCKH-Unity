using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    [SerializeField] GameObject apple;
    [SerializeField] GameObject orange;
    [SerializeField] GameObject banana;
    [SerializeField] GameObject watermelon;

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

    void Update()
    {
        PlayerClick();
    }

    public void Init()
    {
        UIController.instance.TutuarialText.text = "Bạn hãy nhìn thực tế xem quả nào ở bên ngoài to nhất";
        List<Vector3> positions = new List<Vector3>();
        positions.Add(new Vector3(-1.2f, 1.5f, 0f));
        positions.Add(new Vector3(1.2f, 0f, 0f));
        positions.Add(new Vector3(-1.2f, -1.5f, 0f));
        positions.Add(new Vector3(1.2f, -3f, 0f));

        int rd = Random.Range(0, 3);

        apple.transform.position = positions[rd % positions.Count];
        orange.transform.position = positions[(rd + 1) % positions.Count];
        banana.transform.position = positions[(rd + 2) % positions.Count];
        watermelon.transform.position = positions[(rd + 3) % positions.Count];
    }

    public void PlayerClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            Collider2D hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));
            if (hitCollider != null && hitCollider.CompareTag("watermelon"))
            {
                Accepted();
            }
            else if (hitCollider != null && hitCollider.CompareTag("buttonNext"))
            {
                if (check == true)
                {
                    LevelController.instance.NumKey++;
                }
                LevelController.instance.LoadNextLevel();
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
        ///vi load lai file check n se reset mat nen numKey sai
    }
}
