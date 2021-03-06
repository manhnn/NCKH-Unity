using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateBtn : MonoBehaviour
{
    [SerializeField] GameObject _DonePrefab = null;
    [SerializeField] GameObject _NotDonePrefab = null;
    void Awake()
    {
        GameObject tmp;
        for (int i = 1; i < LevelController.instance.ListLevel.Count; i++)
        {
            if (i <= LevelController.ArchiedLevel)
            {
                tmp = Instantiate(_DonePrefab);
                tmp.GetComponent<Button>().onClick.AddListener(
                    () =>
                {
                    LevelController.instance.LoadLevel(i);
                })
            ;
            }
            else
            {
                tmp = Instantiate(_NotDonePrefab);
            }
            tmp.transform.SetParent(this.transform);
            tmp.transform.localScale = Vector3.one;
            tmp.GetComponentInChildren<TMP_Text>().text = i.ToString();

        }
    }
}
