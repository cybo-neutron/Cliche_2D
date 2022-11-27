using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI_game_over : MonoBehaviour
{
    [SerializeField]VisualElement root  = null; 

    

    private void Awake() {
        
        root = GetComponent<UIDocument>().rootVisualElement;

        var restart_button = root.Q<Button>("restart_button");
        var mainMenuButton = root.Q<Button>("gtm_button");

        restart_button.clicked += RestartButtonOnClick;
        mainMenuButton.clicked += ExitButtonOnClick;

        root.Q<VisualElement>("OuterContainer").AddToClassList("disable");

        PlayerController.DeathEvent += onGameOver;

    }

    void RestartButtonOnClick(){
        SceneLoadingManager.Instance.ReloadCurrentScene();
    }

    void ExitButtonOnClick(){
        SceneLoadingManager.Instance.LoadMainMenu();
    }

    void onGameOver(){
        root.Q<VisualElement>("OuterContainer").ToggleInClassList("disable");
    }
}
