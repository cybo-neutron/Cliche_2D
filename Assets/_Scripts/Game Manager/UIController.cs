using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{

    static public Label scoreText;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        scoreText = root.Q<Label>("Score");

    }

    // Update is called once per frame
    void Update()
    {

    }

    static public void UpdateScore(int score)
    {
        scoreText.text = "Score : " + score;
    }
}
