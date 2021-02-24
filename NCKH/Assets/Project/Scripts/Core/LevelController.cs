using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelController : MonoBehaviour
{
    public static LevelController instance = null;
    [Header("Level")]
    public static int CurrentLevel = 1;
    public static int ArchiedLevel = 1;
    [SerializeField] Level _LevelComponent = null;
    [SerializeField] int _Numkey = 0;
    [Header("LoadLevel")]
    [SerializeField] List<GameObject> _ListLevel;
    public int NumKey { get => _Numkey; set => _Numkey = value; }
    public List<GameObject> ListLevel { get => _ListLevel; set => _ListLevel = value; }
    public Level LevelComponent { get => _LevelComponent; set => _LevelComponent = value; }

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
        //Defalt is first level
        LoadLevel();
    }

    public void LoadNextLevel()
    {
        CurrentLevel++;
        LoadLevel(CurrentLevel);
    }

    private void TextUpdate(int level)
    {
        UIController.instance.LevelText.text = "Level: " + (level).ToString();
        UIController.instance.NumberkeyText.text = "Key: " + NumKey.ToString();
    }

    GameObject obj = null;
    public void LoadLevel(int level = 1)
    {
        UIController.instance.SetSuccessPanel(false);
        TextUpdate(level);
        ArchiedLevel = Mathf.Max(ArchiedLevel, CurrentLevel);
        Destroy(obj);
        obj = Instantiate(ListLevel[level - 1], new Vector3(0, 0, 0), Quaternion.identity);
        LevelComponent = obj.GetComponent<Level>();
    }

    public void LevelCorrect(Vector3 Pos)
    {
        UIController.instance.CorrectAnswer(Pos);
    }
    public void LevelWrong(Vector3 Pos)
    {
        UIController.instance.WrongAnswer(Pos);
    }
}
