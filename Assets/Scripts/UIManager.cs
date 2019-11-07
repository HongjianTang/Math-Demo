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
    public GameObject removedNumberGroup;
    private List<GameObject> _playerNumberObjects = new List<GameObject>();
    private List<GameObject> _removedNumberObjects = new List<GameObject>();
    public GameObject stepText;
    public GameObject scoreText;
    public GameObject restartButton;

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

        restartButton.GetComponent<Button>().onClick
            .AddListener(ProcessManager.Instance.RestartGame);
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
    /// 更新玩家数组UI
    /// </summary>
    public void UpdatePlayerNumber()
    {
        UpdateNumberGameObjects(NumberManager.Instance.PlayerNumbers, _playerNumberObjects,
            playerNumberGroup);
    }

    public void UpdateRemovedNumber()
    {
        UpdateNumberGameObjects(NumberManager.Instance.RemovedNumbers, _removedNumberObjects,
            removedNumberGroup);
    }
    
    /// <summary>
    /// 更新数组UI
    /// </summary>
    /// <param name="numbers">数组</param>
    /// <param name="numberObjects">存放的gameObject</param>
    /// <param name="anchor">坐标anchor</param>
    private void UpdateNumberGameObjects(List<int> numbers, List<GameObject> numberObjects,
        GameObject anchor)
    {
        foreach (var number in numberObjects)
        {
            Destroy(number);
        }

        numberObjects.Clear();
        if (numbers == null) return;
        foreach (var t in numbers)
        {
            GameObject numberGameObject =
                Instantiate(numberPrefab, anchor.transform, true);
            numberObjects.Add(numberGameObject);
            numberGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                t.ToString();
        }
    }

    /// <summary>
    /// 更新分数UI
    /// </summary>
    private void UpdateScore()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + NumberManager.Instance.score;
    }

    /// <summary>
    /// 更新步数UI
    /// </summary>
    private void UpdateStep()
    {
        stepText.GetComponent<TextMeshProUGUI>().text = "Step: " + ProcessManager.Instance.nStep;
    }

    /// <summary>
    /// 更新步数和分数UI
    /// </summary>
    public void UpdateAll()
    {
        UpdateScore();
        UpdateStep();
    }

    /// <summary>
    /// 显示重新开始按钮
    /// </summary>
    public void DisplayRestartButton()
    {
        restartButton.SetActive(true);
    }

    /// <summary>
    /// 隐藏重新开始按钮
    /// </summary>
    public void HideRestartButton()
    {
        restartButton.SetActive(false);
    }

    /// <summary>
    /// 使待选数组按钮不可用
    /// </summary>
    public void InactiveNumberButton()
    {
        for (int i = 0; i < 5; i++)
        {
            selectNumber[i].transform.parent.gameObject.GetComponent<Button>().interactable = false;
        }
    }

    /// <summary>
    /// 使待选数组按钮可用
    /// </summary>
    public void ActiveNumberButton()
    {
        for (int i = 0; i < 5; i++)
        {
            selectNumber[i].transform.parent.gameObject.GetComponent<Button>().interactable = true;
        }
    }
}