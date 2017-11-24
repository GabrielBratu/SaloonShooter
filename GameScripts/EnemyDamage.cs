using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour {

    private float timer;
    [SerializeField] private short numberOfGuns;
    [SerializeField] private GameObject[] bangsPrefab;
    [SerializeField] private Transform shootSpawn1;
    [SerializeField] private Transform shootSpawn2;
    private AudioSource enemyShootSound;

    private void Start()
    {
        enemyShootSound = this.GetComponent<AudioSource>();
        enemyShootSound.volume = 0.5f;
    }


    void Update () {
        timer += Time.deltaTime;

        if(timer >= StaticVariables.enemyShootSpeed && StaticVariables.lives > 0) //&& StaticVariables.canFire == true
        {
            StaticVariables.lives--;
            Handheld.Vibrate();
            timer = 0f;
            StaticVariables.hitInRow = 0;
            if (PlayerPrefs.GetInt("sound") == 0)
            {
                enemyShootSound.Play();
            }

            if (numberOfGuns == 1)
            {
                Destroy(Instantiate(bangsPrefab[Random.Range(0, bangsPrefab.Length)], shootSpawn1.position, Quaternion.identity), 0.2f);
            }
            else
            {
                Destroy(Instantiate(bangsPrefab[Random.Range(0, bangsPrefab.Length)], shootSpawn1.position, Quaternion.identity), 0.2f);
                Destroy(Instantiate(bangsPrefab[Random.Range(0, bangsPrefab.Length)], shootSpawn2.position, Quaternion.identity), 0.2f);
            }
        }

	}
}
