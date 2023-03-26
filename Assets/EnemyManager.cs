using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    int playerCurrentHp;
    private GameObject[] enemyObj;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        enemyObj = GameObject.FindGameObjectsWithTag("enemy");
        //player.GetComponent<Player>();
        //playerCurrentHp = player.GetCurrentHp();
        if (enemyObj.Length == 0)
        {
            SceneManager.LoadScene("GameClear");
        }

        //if (playerCurrentHp <= 0)
        //{
        //    SceneManager.LoadScene("GameOver");
        //}
    }
}
