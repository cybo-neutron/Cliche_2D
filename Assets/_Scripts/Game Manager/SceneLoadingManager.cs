using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scenes
{
    public static string main_menu = "main_menu";
    public static string level_01 = "level_01";
}


public class SceneLoadingManager : MonoBehaviour
{

    public static SceneLoadingManager Instance{ get; private set; }

    void Awake()
    {
        if(Instance==null){
            Instance = this;
        }

    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    public void LoadScene(string scene){
        SceneManager.LoadSceneAsync(scene);
    }

    public int ReturnActiveScene()
    {
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        return activeScene;
    }

    public void LoadNextScene(){
        
    }

    public void ReloadCurrentScene(){
        this.LoadScene(this.ReturnActiveScene());
    }

    public void LoadMainMenu(){
        SceneManager.LoadScene(Scenes.main_menu);
    }


}
