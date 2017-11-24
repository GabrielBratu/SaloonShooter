using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreSystem : MonoBehaviour
{

    public Text highscore;
    public int highestScore;

    void Awake()
    {
        highestScore = PlayerPrefs.GetInt("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
           highscore.text = PlayerPrefs.GetInt("Highscore").ToString();    
    }
}
