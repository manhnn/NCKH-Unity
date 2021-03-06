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
            Destroy(this.gameObject);
        }
        ArchiedLevel = GameConfigs.IntLevelKey;
    }

    void Start()
    {
        LoadLevel();
    }

    public void LoadNextLevel()
    {
        if (CurrentLevel < _ListLevel.Count)
            CurrentLevel++;
        else
            Debug.Log("LoadEndScene");
        LoadLevel(CurrentLevel);
    }

    private void TextUpdate(int level)
    {
        UIController.instance.LevelText.text = "Level: " + (level).ToString();
        UIController.instance.NumberkeyText.text = "Key: " + NumKey.ToString();
    }

    GameObject obj = null;
    public void LoadLevel(int level = 0)
    {
        CurrentLevel = level;
        UIController.instance.SetSuccessPanel(false);
        TextUpdate(level);
        ArchiedLevel = Mathf.Max(ArchiedLevel, CurrentLevel);
        GameConfigs.IntLevelKey = ArchiedLevel;
        Destroy(obj);
        obj = Instantiate(ListLevel[level], new Vector3(0, 0, 0), Quaternion.identity);
        LevelComponent = obj.GetComponent<Level>();
    }

    public void LevelCheck(bool iswin, Vector3 pos, float sec = 0)
    {
        if (iswin) LevelCorrect(pos, sec);
        else LevelWrong(pos);
    }
    public void LevelCorrect(Vector3 Pos, float sec = 0f)
    {
        UIController.instance.CorrectAnswer(Pos, sec);
    }
    public void LevelWrong(Vector3 Pos)
    {
        UIController.instance.WrongAnswer(Pos);
    }

    public void BackToMenu()
    {
        ArchiedLevel++;
        GameConfigs.IntLevelKey = ArchiedLevel;
        GameController.instance.LoadHomeScene();
    }
}
