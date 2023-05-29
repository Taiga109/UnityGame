using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class EnemyCountText : MonoBehaviour
{
    public GameObject EnemyCountTextObj;
    public EnemySpawn enemySpawn;
    public EnemyManager enemyManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text wave_text = EnemyCountTextObj.GetComponent<Text>();

        wave_text.text = "Enemy"+ enemyManager.EnemyDeathCount+ "/"+enemySpawn.MaxSpawn;
    }
}
