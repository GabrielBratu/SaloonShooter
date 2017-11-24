using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject[] spawnPoints;
    public int score = 0;
    public int lives = 3;
    public int scoreMultiplyer;
    [HideInInspector] public Collider2D[] spawnCols;
    [HideInInspector] public GameObject[] charInstances;
    [HideInInspector] public SpawnStatus[] spawnStatus;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private GameObject[] ally;
    [SerializeField] private int chanceOfAlly = 20;
    [SerializeField] private int minEnemy = 0;
    [SerializeField] private int maxEnemy = 0;
    [SerializeField] private long threshold = 200;


    private bool waitForSpawn = false;
    private float timer;
    private int chance;
    private int randomPos;
    private int allyPos;
    private int enemyPos;
    private short thresholdCount = 0;
    private int randomEnemy;
    public float spawnWait = 0.25f; // 0.12f
    public float startWait = 0;
    private float waveWait;
    private bool stopFlow = false;


    private void Awake()
    {
        StaticVariables.lives = 3;
        StaticVariables.characterCount = 0;
        StaticVariables.enemyShootSpeed = 3;
        StaticVariables.hitInRow = 0;
        StaticVariables.lives = 3;
        stopFlow = false;
        
}

    private void Start()
    {
        if (PlayerPrefs.GetInt("music") == 0)
        {
            AudioSource bgSoundSource;
            bgSoundSource = this.GetComponent<AudioSource>();
            bgSoundSource.volume = 0.2f;
            bgSoundSource.Play();
        }
        scoreMultiplyer = 1;
        waveWait = 1f;
        spawnStatus = new SpawnStatus[spawnPoints.Length];
        charInstances = new GameObject[spawnPoints.Length];
        spawnCols = new Collider2D[spawnPoints.Length];
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnStatus[i] = spawnPoints[i].GetComponent<SpawnStatus>();
            spawnCols[i] = spawnStatus[i].myCollider;
        }

        minEnemy = 1;
        maxEnemy = 2;
        StaticVariables.enemyShootSpeed = 2.00f;

        StartCoroutine(SpawnWaves());

    }

    private void Update()
    {
        if (!isGameFinished)
        {
            ////timer += Time.deltaTime;
            Debug.Log(StaticVariables.lives);
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (charInstances[i] == null)
                {
                    spawnStatus[i].isUsed = false;
                    spawnStatus[i].hold = "";
                }
            }
            Debug.Log("Multiplyer: " + scoreMultiplyer);
            //diff lvl creation
            LevelDifficulty();

        }
        else
        {
            if (stopFlow == false)
            {
                GameManager.instance.deathCount++;
                Debug.Log("Deaths:" + GameManager.instance.deathCount);
                StaticVariables.canFire = false;
                Debug.Log(StaticVariables.canFire);
                uiManager.GetComponent<UIManager>().die.gameObject.SetActive(true);
                uiManager.GetComponent<UIManager>().dieScore.gameObject.SetActive(true);
                uiManager.GetComponent<UIManager>().scoreAndLife.gameObject.SetActive(false);
                uiManager.GetComponent<UIManager>().restart.gameObject.SetActive(true);
                uiManager.GetComponent<UIManager>().mainMenu.gameObject.SetActive(true);

                if (score > PlayerPrefs.GetInt("Highscore"))
                {
                    PlayerPrefs.SetInt("Highscore", score);
                    FBManager.Instance.SetScore();
                }
                stopFlow = true;          
            }
        }


    }

    private void FillWithEnemies()
    {
        if (haveSpace && !isGameFinished)
        {
            enemyPos = Random.Range(0, spawnPoints.Length);
            if (spawnStatus[enemyPos].isUsed == false && waitForSpawn == false)
            {
                waitForSpawn = true;
                spawnStatus[enemyPos].isUsed = true;
                StaticVariables.characterCount++;
                randomEnemy = Random.Range(0, enemy.Length);
                charInstances[enemyPos] = Instantiate(enemy[randomEnemy],
                                                      spawnPoints[enemyPos].transform.position,
                                                      Quaternion.identity);
                switch (randomEnemy)
                {
                    case 0:
                        spawnStatus[enemyPos].type = "20p"; // 20
                        break;
                    case 1:
                        spawnStatus[enemyPos].type = "25p";
                        break;
                }
                spawnStatus[enemyPos].hold = "enemy";
                waitForSpawn = false;
            }
            else
            {
                if (haveSpace)
                {
                    FillWithEnemies();
                }
            }
        }
    }

    private void FillWithAllies()
    {
        if (haveSpace && !isGameFinished)
        {
            allyPos = Random.Range(0, spawnPoints.Length);
            if (spawnStatus[allyPos].isUsed == false && waitForSpawn == false)
            {
                waitForSpawn = true;
                spawnStatus[allyPos].isUsed = true;
                StaticVariables.characterCount++;
                charInstances[allyPos] = Instantiate(ally[Random.Range(0, enemy.Length)], 
                    spawnPoints[allyPos].transform.position, Quaternion.identity);
                spawnStatus[allyPos].hold = "ally";
                waitForSpawn = false;
            }
            else
            {
                if (haveSpace)
                {
                    FillWithAllies();
                }
            }
        }
    }

    private bool haveSpace
    {
        get
        {
            return StaticVariables.characterCount < spawnPoints.Length;
        }
    }

    private bool isGameFinished
    {
        get
        {
            return StaticVariables.lives <= 0;
        }
    }

    private void SpawnEnemy(int _minEnemy, int _maxEnemy, float _shootSpeed)
    {
        if (haveSpace && !isGameFinished)
        {
            chance = Random.Range(0, 100);
            if (chance <= chanceOfAlly)
            {
                FillWithAllies();
            }
            else
            {
                FillWithEnemies();
            }

        }
    }

    private void LevelDifficulty()
    {
        if (score > threshold)
        {
            threshold *= 2;
            thresholdCount++;
            StaticVariables.enemyShootSpeed -= (float)(StaticVariables.enemyShootSpeed * 0.15f);
            if (thresholdCount % 2 == 0 && thresholdCount != 0 && (minEnemy < 3 && maxEnemy < 5))
            {
                minEnemy++;
                maxEnemy++;
            }
        }
    }

    public void IncreaseScore(string type)
    {

        switch (type)
        {

            case "20p":
                score += 20 * scoreMultiplyer;           //MODIFICARI SCOR   
                break;
            case "25p":
                score += 25 * scoreMultiplyer;
                break;
        }

    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);


        while (true)
        {
            int tmpNumberOfChar;
            tmpNumberOfChar = Random.Range(minEnemy, maxEnemy + 1);
            // Only pick a new spawn point once per wave
            //  int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Debug.Log("Min Enemy: " + minEnemy + "Max Enemy: " + maxEnemy);
            for (int i = 0; i < tmpNumberOfChar; i++)
            {
                // here would pick a new spawn point for each new enemy
                SpawnEnemy(minEnemy, maxEnemy, StaticVariables.enemyShootSpeed);

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            Debug.Log(waveWait);
        }
    }
}