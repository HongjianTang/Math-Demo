using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NumberManager : MonoBehaviour
{
    [NonSerialized] public readonly List<int> ToSelectNumbers = new List<int>();
    private readonly List<int> _playerNumbers = new List<int>();
    private readonly List<int> _progressionNumbers = new List<int>();
    private int _score;
    private int _scoreInterval;
    public static NumberManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ClearList()
    {
        ToSelectNumbers.Clear();
    }
    
    /// <summary>
    /// 产生单个随机数
    /// </summary>
    public void GenerateSingleRandomNumber()
    {
        ToSelectNumbers.Add(Random.Range(1, 100));
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
        _playerNumbers.Add(n);
        gameObject.GetComponent<ProcessManager>().CheckPhase();
    }

    /// <summary>
    /// 检查是否存在等差数列
    /// </summary>
    public void CheckArithmeticProgression()
    {
        for (int i = 0; i < _playerNumbers.Count - 3; i++)
        {
            for (int j = i + 1; j < _playerNumbers.Count - 2; j++)
            {
                int n3 = 2 * _playerNumbers[j] - _playerNumbers[i];
                for (int k = j + 1; k < _playerNumbers.Count - 1; k++)
                {
                    if (_playerNumbers[k] == n3)
                    {
                        int n4 = 2 * _playerNumbers[k] - _playerNumbers[j];
                        for (int l = k + 1; l < _playerNumbers.Count; l++)
                        {
                            if (_playerNumbers[l] == n4)
                            {
                                _progressionNumbers.Add(_playerNumbers[i]);
                                _progressionNumbers.Add(_playerNumbers[j]);
                                _progressionNumbers.Add(_playerNumbers[k]);
                                _progressionNumbers.Add(_playerNumbers[l]);
                                _scoreInterval = l - i - 3;
                                AddScoreAnimation();
                            }
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void AddScoreAnimation()
    {
        AddScore(_scoreInterval);
        RemoveNumber(_progressionNumbers[0]);
        RemoveNumber(_progressionNumbers[1]);
        RemoveNumber(_progressionNumbers[2]);
        RemoveNumber(_progressionNumbers[3]);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="n"></param>
    public void RemoveNumber(int n)
    {
        _playerNumbers.Remove(n);
        // 播放动画
    }

    /// <summary>
    /// 
    /// </summary>
    public void AddScore(int n)
    {
        _score += n;
        // 播放动画
    }
}