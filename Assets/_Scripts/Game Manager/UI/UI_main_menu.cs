using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI_main_menu : MonoBehaviour
{
    

    void Awake(){
        var root = GetComponent<UIDocument>().rootVisualElement;

        root.Q<Button>("start").clicked += () =>
        {
            Debug.Log("Hello world");
        };
    }
}
