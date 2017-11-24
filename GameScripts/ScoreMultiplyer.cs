using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplyer : MonoBehaviour {
    private EnemySpawn enemySpawn;
    private int resetMultiplyer;

	// Use this for initialization
	void Start () {
        enemySpawn = this.GetComponent<EnemySpawn>();
        resetMultiplyer = StaticVariables.lives; 
	}

    // Update is called once per frame
    void Update()
    {
        if (resetMultiplyer > StaticVariables.lives)
        {
            resetMultiplyer = StaticVariables.lives;
            enemySpawn.scoreMultiplyer = 1;
        }

        if (StaticVariables.hitInRow % 5 == 0 && StaticVariables.hitInRow != 0 && enemySpawn.scoreMultiplyer < 5)
        {
            enemySpawn.scoreMultiplyer++;
            StaticVariables.hitInRow = 0;
        }
        //else if (StaticVariables.hitInRow % 5 == 0 && StaticVariables.hitInRow == 0 && enemySpawn.scoreMultiplyer < 5)
        //{
        //    enemySpawn.scoreMultiplyer = 1;
        //}
    }

    //public void SM()
    //{
        //if (resetMultiplyer<StaticVariables.lives)
        //{
        //    resetMultiplyer = StaticVariables.lives;

        //}

    //    if (StaticVariables.hitInRow % 5 == 0 && StaticVariables.hitInRow != 0 && enemySpawn.scoreMultiplyer < 5)
    //    {
    //        enemySpawn.scoreMultiplyer++;
    //    }
    //    else if (StaticVariables.hitInRow % 5 == 0 && StaticVariables.hitInRow == 0 && enemySpawn.scoreMultiplyer < 5)
    //    {
    //        enemySpawn.scoreMultiplyer = 1;
    //    }

    

    
}
