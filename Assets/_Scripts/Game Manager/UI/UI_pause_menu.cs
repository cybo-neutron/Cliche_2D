using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class UI_pause_menu : MonoBehaviour
{
    [SerializeField]VisualElement root  = null; 

    private void Awake() {
        
        root = GetComponent<UIDocument>().rootVisualElement;

        var resume_button = root.Q<Button>("resume_button");
        var restart_button = root.Q<Button>("restart_button");
        var exit_button = root.Q<Button>("exit_button");


        resume_button.clicked += ResumeButtonOnClick;
        restart_button.clicked += RestartButtonOnClick;
        exit_button.clicked += ExitButtonOnClick;

        root.Q<VisualElement>("OuterContainer").AddToClassList("disable");

    }

    private void Update(){
       

        if(Input.GetKeyDown(KeyCode.Escape)){
            //todo : Pause the game
            TogglePauseMenu();
        }

    }

    void TogglePauseMenu(){
        root.Q<VisualElement>("OuterContainer").ToggleInClassList("disable");
    }

    void ResumeButtonOnClick(){
        //hide the pause menu
        TogglePauseMenu();
    }

    void RestartButtonOnClick(){
        SceneLoadingManager.Instance.ReloadCurrentScene();
    }

    void ExitButtonOnClick(){
        SceneLoadingManager.Instance.LoadMainMenu();
    }

    private void OnEnable() {
        Debug.Log("Pause menu enabled");
    }

    private void OnDisable() {
        
    }

}
