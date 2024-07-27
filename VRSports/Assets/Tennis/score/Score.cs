using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private static int _playerScore = 0;
    public static int PlayerScore
    {
        set { _playerScore = value; }
        get { return _playerScore; }
    }

    private int addScore = 1;
    void Start()
    {
        _playerScore = 0;
    }

    public static void AddScore()
    {
        int tmep = PlayerScore;
        tmep++;
        PlayerScore = tmep;
    }

}
