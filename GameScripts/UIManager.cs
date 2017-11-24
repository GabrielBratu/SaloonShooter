using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public int score;
    public Text textScore;
    public Text dieScore;
    public Image die;
    [SerializeField] EnemySpawn enemySpawn;
    public Text comboText;
    public Image lifeI;
    public Image lifeII;
    public Image lifeIII;
    public Image scoreAndLife;
    public Button mainMenu;
    public Button restart;


    private void Start()
    {
        mainMenu = mainMenu.GetComponent<Button>();
        restart = restart.GetComponent<Button>();
        textScore = textScore.GetComponent<Text>();
        dieScore = dieScore.GetComponent<Text>();
        die = die.GetComponent<Image>();
        scoreAndLife = scoreAndLife.GetComponent<Image>();
        comboText = comboText.GetComponent<Text>();
        die.gameObject.SetActive(false);
        dieScore.gameObject.SetActive(false);
        scoreAndLife.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
       
        textScore.text = "0";
        comboText.text = "X1";
    }

    private void Update()
    {
        comboText.text = "X" + enemySpawn.scoreMultiplyer.ToString();
        Lifes();
    }

    public void SetScoreOnScreen()
    {
        textScore.text = "" + enemySpawn.score.ToString();
        dieScore.text = "" + textScore.text.ToString();
    }

    public void Lifes()
    {
        if (StaticVariables.lives == 2)
        {
            lifeI.enabled = false;
        }
        if (StaticVariables.lives == 1)
        {
            lifeIII.enabled = false;
        }
        if (StaticVariables.lives == 0)
        {
            lifeII.enabled = false;
        }

    }
}
