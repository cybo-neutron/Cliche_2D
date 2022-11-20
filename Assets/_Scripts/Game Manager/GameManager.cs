using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static int score = 0;

    void Start()
    {
        score = 0;
    }

    public void Update()
    {
        
    }

    static public void UpdateScore(int _score)
    {
        score += _score;
        UIController.UpdateScore(score);
    }




}
