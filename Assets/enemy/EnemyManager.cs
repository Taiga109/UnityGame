using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
   
    private GameObject[] enemyObj;
    private GameObject[] Bullet_enemyObj;

    public EnemySpawn enemySpawn;
    public int EnemyDeathCount = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemyObj = GameObject.FindGameObjectsWithTag("enemy");
        Bullet_enemyObj = GameObject.FindGameObjectsWithTag("Bullet_enemy");

        if (enemySpawn.EndWave == true)
        {
                SceneManager.LoadScene("GameClear");

        }
    }
}
