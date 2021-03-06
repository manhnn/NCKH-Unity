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
        for (int i = 1; i < LevelController.instance.ListLevel.Count; i++)
        {
            GameObject tmp;
            if (i <= LevelController.ArchiedLevel)
            {
                tmp = Instantiate(_DonePrefab);
                tmp.name = string.Format("{0}", i);
                tmp.GetComponent<Button>().onClick.AddListener
                (
                    () =>
                {
                    LevelController.instance.LoadLevel(int.Parse(tmp.name.ToString()));
                }
                )
                ;
            }
            else
            {
                tmp = Instantiate(_NotDonePrefab);
                tmp.name = string.Format("{0}", i);
            }
            tmp.transform.SetParent(this.transform);
            tmp.transform.localScale = Vector3.one;
            tmp.GetComponentInChildren<TMP_Text>().text = i.ToString();

        }
    }
}
