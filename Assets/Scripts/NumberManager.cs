using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberManager : MonoBehaviour
{
    private List<int> _toSelectNumbers = new List<int>();
    
    /// <summary>
    /// 
    /// </summary>
    public void GenerateSingleRandomNumber()
    {
        _toSelectNumbers.Add(Random.Range(1, 100));
    }

    /// <summary>
    /// 
    /// </summary>
    public void GenerateRandomNumber()
    {
        for (int i = 0; i < 5; i++)
        {
            GenerateSingleRandomNumber();
        }
    }

    public void CheckAvailableArray()
    {
        
    }
}
