using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    [SerializeField]private UIManager uiManager;
    [SerializeField] private EnemySpawn enemySpawn;
    private AudioSource shootSound;

    private void Start()
    {
        if (PlayerPrefs.GetInt("sound") == 0)
        {
            shootSound = this.GetComponent<AudioSource>();
            shootSound.volume = 0.5f;
        }
        uiManager = uiManager.GetComponent<UIManager>();
        enemySpawn = enemySpawn.GetComponent<EnemySpawn>();
    }

    private void Update()
    {
        if (Input.touchCount == 1 && StaticVariables.lives > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPos = new Vector2(wp.x, wp.y);
            //Do the things for touch
            OnTouchActions(touchPos);
            if (PlayerPrefs.GetInt("sound") == 0)
            {
                shootSound.Play();
            }


        }
        if (Input.GetMouseButtonDown(0) && StaticVariables.lives > 0)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 touchPos = new Vector2(wp.x, wp.y);
            //Do the things for touch
            OnTouchActions(touchPos);
            if (PlayerPrefs.GetInt("sound") == 0)
            {
                shootSound.Play();
            }

        }
    }


    private void OnTouchActions(Vector2 _touchPos)
    {
        for (int i = 0; i < enemySpawn.spawnPoints.Length; i++)
        {
            if (enemySpawn.spawnCols[i] == Physics2D.OverlapPoint(_touchPos))
            {
                if (enemySpawn.charInstances[i] != null)
                {
                    if (enemySpawn.spawnStatus[i].hold == "enemy")
                    {
                        enemySpawn.IncreaseScore(enemySpawn.spawnStatus[i].type);
                        uiManager.SetScoreOnScreen();
                        StaticVariables.characterCount--;
                        StaticVariables.hitInRow++;
                        enemySpawn.spawnStatus[i].isUsed = false;
                        enemySpawn.spawnStatus[i].hold = "";
                        enemySpawn.spawnStatus[i].type = "";
                        Destroy(enemySpawn.charInstances[i]);
                    }

                    if (enemySpawn.spawnStatus[i].hold == "ally")
                    {
                        
                        StaticVariables.hitInRow = 0;
                        StaticVariables.lives--;
                        StaticVariables.characterCount--;
                        enemySpawn.spawnStatus[i].isUsed = false;
                        enemySpawn.spawnStatus[i].hold = "";
                        Destroy(enemySpawn.charInstances[i]);
                    }
                }
            }
        }
    }
}