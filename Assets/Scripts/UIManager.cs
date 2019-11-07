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
    public GameObject numberPrefab;
    public GameObject playerNumberGroup;
    private List<GameObject> _playerNumberObjects = new List<GameObject>();
    public GameObject stepText;
    public GameObject scoreText;

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
            var i1 = i;
            selectNumber[i].transform.parent.gameObject.GetComponent<Button>().onClick
                .AddListener(() => NumberManager.Instance.SelectNumber(i1));
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

    /// <summary>
    /// 
    /// </summary>
    public void UpdatePlayerNumber()
    {
        foreach (var number in _playerNumberObjects)
        {
            Destroy(number);
        }

        _playerNumberObjects.Clear();
        for (int i = 0; i < NumberManager.Instance.PlayerNumbers.Count; i++)
        {
            GameObject numberGameObject =
                Instantiate(numberPrefab, playerNumberGroup.transform, true);
            _playerNumberObjects.Add(numberGameObject);
            numberGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                NumberManager.Instance.PlayerNumbers[i].ToString();
        }
    }

    public void UpdateScore()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + NumberManager.Instance.score;
    }

    public void UpdateStep()
    {
        stepText.GetComponent<TextMeshProUGUI>().text = "Step: " + ProcessManager.Instance.nStep;
    }

    public void UpdateAll()
    {
        UpdateScore();
        UpdateStep();
    }
}