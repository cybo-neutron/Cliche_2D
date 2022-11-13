using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]SceneLoadingManager _sceneLoadingManager;
    static int score = 0;

    void Start()
    {
        score = 0;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
            RestartGame();
    }

    static public void UpdateScore(int _score)
    {
        score += _score;
        UIController.UpdateScore(score);
    }

    public void RestartGame()
    {
        _sceneLoadingManager.LoadScene(_sceneLoadingManager.activeScene);
    }



}
