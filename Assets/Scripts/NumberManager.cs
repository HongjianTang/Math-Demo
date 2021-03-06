﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NumberManager : MonoBehaviour
{
    [NonSerialized] public readonly List<int> ToSelectNumbers = new List<int>();
    [NonSerialized] public readonly List<int> PlayerNumbers = new List<int>();
    [NonSerialized] public readonly List<int> RemovedNumbers = new List<int>();
    private readonly List<int> _progressionNumbers = new List<int>();
    [NonSerialized] public int score;
    private int _scoreInterval;
    public static NumberManager Instance;
    private const int NLimit = 50;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// 清除待选数组
    /// </summary>
    public void ClearSelectNumber()
    {
        ToSelectNumbers.Clear();
    }

    /// <summary>
    /// 产生单个随机数
    /// </summary>
    private void GenerateSingleRandomNumber()
    {
        int n = Random.Range(1, NLimit);
        while (PlayerNumbers.Contains(n))
        {
            n = Random.Range(1, NLimit);
        }
        ToSelectNumbers.Add(n);
    }

    /// <summary>
    /// 产生5个随机数
    /// </summary>
    public void GenerateRandomNumber()
    {
        for (int i = 0; i < 5; i++)
        {
            GenerateSingleRandomNumber();
        }
    }

    /// <summary>
    /// 玩家选择数字
    /// </summary>
    /// <param name="n"></param>
    public void SelectNumber(int n)
    {
        PlayerGetNumber(ToSelectNumbers[n]);
    }

    /// <summary>
    /// 玩家获得数字
    /// </summary>
    /// <param name="n"></param>
    public void PlayerGetNumber(int n)
    {
        PlayerNumbers.Add(n);
        PlayerNumbers.Sort();
        gameObject.GetComponent<ProcessManager>().CheckPhase();
    }

    /// <summary>
    /// 检查是否存在等差数列
    /// </summary>
    public void CheckArithmeticProgression()
    {
        for (int i = 0; i < PlayerNumbers.Count - 3; i++)
        {
            for (int j = i + 1; j < PlayerNumbers.Count - 2; j++)
            {
                int n3 = 2 * PlayerNumbers[j] - PlayerNumbers[i];
                for (int k = j + 1; k < PlayerNumbers.Count - 1; k++)
                {
                    if (PlayerNumbers[k] == n3)
                    {
                        int n4 = 2 * PlayerNumbers[k] - PlayerNumbers[j];
                        for (int l = k + 1; l < PlayerNumbers.Count; l++)
                        {
                            if (PlayerNumbers[l] == n4)
                            {
                                _progressionNumbers.Add(PlayerNumbers[i]);
                                _progressionNumbers.Add(PlayerNumbers[j]);
                                _progressionNumbers.Add(PlayerNumbers[k]);
                                _progressionNumbers.Add(PlayerNumbers[l]);
                                print("zhaodaole!" + _progressionNumbers[0]);
                                print(_progressionNumbers[1]);
                                print(_progressionNumbers[2]);
                                print(_progressionNumbers[3]);
                                _scoreInterval = l - i + 1;
                                AddScoreAnimation();
                            }
                        }
                    }
                }
            }
        }
    }

    public void CheckArithmeticProgression2()
    {
        for (int i = 0; i < PlayerNumbers.Count - 3; i++)
        {
            for (int j = i + 1; j < PlayerNumbers.Count - 2; j++)
            {
                int n3 = 2 * PlayerNumbers[j] - PlayerNumbers[i];
                int n4 = 3 * PlayerNumbers[j] - 2 * PlayerNumbers[i];
                var k = PlayerNumbers.FindIndex(x => x == n3);
                var l = PlayerNumbers.FindIndex(x => x == n4);
            }
        }
    }

    /// <summary>
    /// 添加分数，并播放动画
    /// </summary>
    private void AddScoreAnimation()
    {
        AddScore(_scoreInterval);
        RemoveNumber(_progressionNumbers[0]);
        RemoveNumber(_progressionNumbers[1]);
        RemoveNumber(_progressionNumbers[2]);
        RemoveNumber(_progressionNumbers[3]);
        _progressionNumbers.Clear();
        UIManager.Instance.UpdatePlayerNumber();
        UIManager.Instance.UpdateRemovedNumber();
    }

    /// <summary>
    /// 移除该数字
    /// </summary>
    /// <param name="n"></param>
    public void RemoveNumber(int n)
    {
        RemovedNumbers.Add(n);
        PlayerNumbers.Remove(n);
        // 播放动画
    }

    /// <summary>
    /// 增加分数并播放动画
    /// </summary>
    public void AddScore(int n)
    {
        score += n;
        print("本次得分：" + n + "，总分：" + score);
        // 播放动画
    }

    /// <summary>
    /// 重新开始游戏，重置分数和数组
    /// </summary>
    public void ClearCache()
    {
        PlayerNumbers.Clear();
        RemovedNumbers.Clear();
        score = 0;
    }
}