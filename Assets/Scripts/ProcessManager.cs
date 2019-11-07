using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessManager : MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(InitPhase), 1f);
    }

    void InitGame()
    {
        
    }

    void InitPhase()
    {
        NumberManager.Instance.ClearList();
        NumberManager.Instance.GenerateRandomNumber();
        UIManager.Instance.UpdateSelectNumber();
    }

    public void CheckPhase()
    {
        UIManager.Instance.UpdatePlayerNumber();
        NumberManager.Instance.CheckArithmeticProgression();
        InitPhase();
    }

    void EndGame()
    {
        
    }
}
