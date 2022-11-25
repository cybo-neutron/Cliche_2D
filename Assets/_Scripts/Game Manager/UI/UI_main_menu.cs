using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UI_main_menu : MonoBehaviour
{
    

    void Awake(){
        var root = GetComponent<UIDocument>().rootVisualElement;

        root.Q<Button>("start").clicked += StartButtonOnClick;
        root.Q<Button>("exit").clicked += ExitButtonOnClick;
        //todo : add options menu

    }

    void StartButtonOnClick(){

        Debug.Log("Starting the game");

        //todo: load the last active scene
        // SceneLoadingManager.Instance.LoadScene(Scenes.level_01);
        SceneLoadingManager.Instance.LoadNextScene();
    }

    void ExitButtonOnClick(){
        Debug.Log("Exit button Clicked");
        Application.Quit();
    }
}
