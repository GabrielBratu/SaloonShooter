using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {
    private float timer;
    private EnemySpawn enemySpawn;
    [SerializeField] private float lifeTime = 8.0f;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            StaticVariables.characterCount--;
            Destroy(gameObject);
        }
    }
}
