using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessManager : MonoBehaviour
{
    public static ProcessManager Instance;
    [NonSerialized] public int nStep = 1;
    private const int NStepLimit = 20;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Invoke(nameof(RegenerateSelectNumberPhase), 0.2f);
    }

    void InitGame()
    {
    }

    /// <summary>
    /// 再次生成待选数组
    /// </summary>
    void RegenerateSelectNumberPhase()
    {
        NumberManager.Instance.ClearSelectNumber();
        NumberManager.Instance.GenerateRandomNumber();
        UIManager.Instance.UpdateSelectNumber();
    }

    /// <summary>
    /// 检查等差数列阶段
    /// </summary>
    public void CheckPhase()
    {
        nStep += 1;
        CheckStepLimit();
        UIManager.Instance.UpdatePlayerNumber();
        RegenerateSelectNumberPhase();
        NumberManager.Instance.CheckArithmeticProgression();
        UIManager.Instance.UpdateAll();
    }

    /// <summary>
    /// 结束游戏
    /// </summary>
    void EndGame()
    {
        UIManager.Instance.DisplayRestartButton();
        UIManager.Instance.InactiveNumberButton();
    }

    /// <summary>
    /// 检查是否到达步数限制
    /// </summary>
    void CheckStepLimit()
    {
        if (nStep > NStepLimit)
        {
            EndGame();
        }
    }

    /// <summary>
    /// 重新开始游戏
    /// </summary>
    public void RestartGame()
    {
        UIManager.Instance.HideRestartButton();
        UIManager.Instance.ActiveNumberButton();
        ClearCache();
        RegenerateSelectNumberPhase();
        UIManager.Instance.UpdatePlayerNumber();
        UIManager.Instance.UpdateAll();
    }

    /// <summary>
    /// 重新开始游戏，重置变量
    /// </summary>
    public void ClearCache()
    {
        nStep = 1;
        NumberManager.Instance.ClearCache();
    }
}