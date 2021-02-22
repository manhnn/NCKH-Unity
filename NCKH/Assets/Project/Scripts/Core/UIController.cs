using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance = null;
    [Header("UI")]
    [SerializeField] TMP_Text _NumberkeyText;
    [SerializeField] TMP_Text _LevelText;
    [SerializeField] GameObject _SuggestionIcon = null;
    [SerializeField] GameObject _TutuarialPanel = null;
    [SerializeField] TMP_Text _TutuarialText = null;

    public TMP_Text NumberkeyText { get => _NumberkeyText; set => _NumberkeyText = value; }
    public TMP_Text LevelText { get => _LevelText; set => _LevelText = value; }
    public GameObject SuggestionIcon { get => _SuggestionIcon; set => _SuggestionIcon = value; }
    public GameObject TutuarialPanel { get => _TutuarialPanel; set => _TutuarialPanel = value; }
    public TMP_Text TutuarialText { get => _TutuarialText; set => _TutuarialText = value; }

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

    public void SetTutuarialPanel(bool activeseft)
    {
        if (activeseft)
        {
            SuggestionIcon.SetActive(false);
            TutuarialPanel.SetActive(true);
            if (GameController.instance.NumKey > 0)
            {
                GameController.instance.NumKey--;
                NumberkeyText.text = "Key: " + GameController.instance.NumKey.ToString();
            }
            else
            {
                TutuarialText.text = "Bạn không có chìa khóa để mở gợi ý";
            }
        }
        else
        {
            SuggestionIcon.SetActive(true);
            TutuarialPanel.SetActive(false);
        }
    }
}
