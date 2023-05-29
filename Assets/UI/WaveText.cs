using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class WaveText : MonoBehaviour
{
    public GameObject WaveTextObj;
    public EnemySpawn enemySpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text wave_text = WaveTextObj.GetComponent<Text>();

        wave_text.text = "Wave:" + enemySpawn.NowWave;
    }
}
