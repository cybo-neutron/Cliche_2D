using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadingManager : MonoBehaviour
{
    [HideInInspector] public int activeScene;

    void Awake()
    {
        ReturnActiveScene();
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    public void ReturnActiveScene()
    {
        activeScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextScent(){
        
    }


}
