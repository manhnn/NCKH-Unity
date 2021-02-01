using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int level = 1;
    public int numKey = 0;

    [SerializeField] List<GameObject> listGameObject;

    [SerializeField] GameObject level1;
    [SerializeField] GameObject level2;
    [SerializeField] GameObject level3;
    [SerializeField] GameObject level4;
    [SerializeField] GameObject level5;
    [SerializeField] GameObject level6;

    public TextMesh numKeyText;
    [SerializeField] TextMesh levelText;

    GameObject obj;
    void Start()
    {
        AddLevelToList();
        NewTurn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddLevelToList()
    {
        listGameObject.Add(level1);
        listGameObject.Add(level2);
        listGameObject.Add(level3);
        listGameObject.Add(level4);
        listGameObject.Add(level5);
        listGameObject.Add(level6);
    }

    public void NewTurn()
    {
        levelText.text = "Level: " + level.ToString();
        numKeyText.text = "Key: " + numKey.ToString();
        LoadLevel();
    }

    public void LoadLevel()
    {
        //Index of list from 0;
        obj = Instantiate(listGameObject[level - 1], new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void DestroyGameObj()
    {
        Destroy(obj);
    }
}
