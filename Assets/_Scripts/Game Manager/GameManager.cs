using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static int score = 0;
    bool _isGameOver = false;

    void Start()
    {
        score = 0;
        PlayerController.DeathEvent += onPlayerDeath;
    }

    static public void UpdateScore(int _score)
    {
        score += _score;
        UIController.UpdateScore(score);
    }

    void onPlayerDeath(){
        _isGameOver = true;
    }

    public bool isGameOver(){
        return _isGameOver;
    }



}
