using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public static GameController instance = null;
    [Header("Level")]
    [SerializeField] int _CurrentLevel = 0;
    [SerializeField] int _Numkey = 0;
    [Header("Game")]
    [SerializeField] List<GameObject> _ListLevel;
    [SerializeField] List<GameObject> _PlayedListLevel;
    public int NumKey { get => _Numkey; set => _Numkey = value; }
    public int CurrentLevel { get => _CurrentLevel; set => _CurrentLevel = value; }
    public List<GameObject> PlayedListLevel { get => _PlayedListLevel; set => _PlayedListLevel = value; }
    public List<GameObject> ListLevel { get => _ListLevel; set => _ListLevel = value; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        LoadLevel(0);
    }

    public void LoadNextLevel()
    {
        LoadLevel(CurrentLevel + 1);
    }

    private void TextUpdate()
    {
        UIController.instance.LevelText.text = "Level: " + (CurrentLevel + 1).ToString();
        UIController.instance.NumberkeyText.text = "Key: " + NumKey.ToString();
    }

    public void LoadLevel(int level)
    {
        //Index of list from 0;
        CurrentLevel = level;
        TextUpdate();
        GameObject obj;
        obj = Instantiate(ListLevel[CurrentLevel], new Vector3(0, 0, 0), Quaternion.identity);
        PlayedListLevel.Add(obj);
        ChangeStage();
    }

    public void ChangeStage()
    {

        if (CurrentLevel - 1 >= 0)
            PlayedListLevel[CurrentLevel - 1].SetActive(false);
        PlayedListLevel[CurrentLevel].SetActive(true);
    }
}
