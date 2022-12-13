using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{

    private GameObject[] enemyObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyObj = GameObject.FindGameObjectsWithTag("enemy");

        if (enemyObj.Length == 0)
        {
            SceneManager.LoadScene("GameClear");
        }
    }
}
