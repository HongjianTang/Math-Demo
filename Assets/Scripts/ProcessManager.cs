using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessManager : MonoBehaviour
{
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
        NumberManager.Instance.ClearList();
        NumberManager.Instance.GenerateRandomNumber();
        UIManager.Instance.UpdateSelectNumber();
    }

    /// <summary>
    /// 检查阶段
    /// </summary>
    public void CheckPhase()
    {
        UIManager.Instance.UpdatePlayerNumber();
        RegenerateSelectNumberPhase();
        NumberManager.Instance.CheckArithmeticProgression();
    }

    void EndGame()
    {
        
    }
}
