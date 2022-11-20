using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{

    [SerializeField] private UI_pause_menu _Pause_Menu;
    bool isPauseMenuEnabled = false;

    void Awake()
    {
        isPauseMenuEnabled = _Pause_Menu.isActiveAndEnabled;
        Debug.Log("Pause Menu : " + isPauseMenuEnabled);
    }

    private void Update() {
        // if(Input.GetKeyDown(KeyCode.Escape)){

        //     if(!isPauseMenuEnabled)
        //     {
        //         //todo : Stop everything and every interactions

        //         //enable pause menu
        //         _Pause_Menu.gameObject.SetActive(true);
        //     }else{
        //         _Pause_Menu.gameObject.SetActive(false);
        //     }
            
        // }  
          
    }
}
