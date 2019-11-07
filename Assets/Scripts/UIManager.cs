using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public List<GameObject> selectNumber = new List<GameObject>();
    private List<TextMeshProUGUI> _selectNumberText = new List<TextMeshProUGUI>();
    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < 5; i++)
        {
            _selectNumberText.Add(selectNumber[i].GetComponent<TextMeshProUGUI>());
        }
        
        // add listener
        for (int i = 0; i < 5; i++)
        {
            selectNumber[i].transform.parent.gameObject.GetComponent<Button>().onClick
                .AddListener(() => NumberManager.Instance.SelectNumber(i));
        }
    }

    /// <summary>
    /// update待选数组
    /// </summary>
    public void UpdateSelectNumber()
    {
        for (int i = 0; i < 5; i++)
        {
            _selectNumberText[i].text = NumberManager.Instance.ToSelectNumbers[i].ToString();
        }
    }

    public void UpdatePlayerNumber()
    {
        
    }
}
