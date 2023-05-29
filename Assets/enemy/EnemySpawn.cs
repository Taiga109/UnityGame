using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawn : MonoBehaviour
{
    public GameObject EnemyPrefab_A;

    public GameObject EnemyPrefab_B;

    [SerializeField]
    private ParticleSystem particle;

    public EnemyManager enemyManager;

    private GameObject[] enemyObj;
    private GameObject[] Bullet_enemyObj;
    //生成時間
    private float interval;
    //時間
    private float time = 0f;

    //ランダムスポーン座標
    //X最小
    public float XminPos = -30f;
    //X最大
    public float XmaxPos = 30f;

    //Z最小
    public float ZminPos = -30f;
    //Z最大
    public float ZmaxPos = 30f;

    int EnemyType = 0;

    public int MaxSpawn = 4;
    private int NowSpawnCount = 0;

    private bool SpawnStop = false;
    public bool EndWave = false;
    public int NowWave = 1;
    public enum Wave
    {
        wave_1 = 3,
        wave_2 = 6,
        wave_3 = 10,
        wave_4 = 14,
    }

    // Start is called before the first frame update
    void Start()
    {
        interval = 5f;
        MaxSpawn = (int)Wave.wave_1;
    }

    // Update is called once per frame
    void Update()
    {
        enemyObj = GameObject.FindGameObjectsWithTag("enemy");
        Bullet_enemyObj = GameObject.FindGameObjectsWithTag("Bullet_enemy");

        time += Time.deltaTime;

        if (time > interval)
        {
            NextWave();
            if (SpawnStop == false)
            {
                EnemyType = Random.Range(1, 3);

                SetEnemySpawn(EnemyType);
            }
            time = 0f;
        }
    }

    //ランダム位置生成
    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(XminPos, XmaxPos);
        float z = Random.Range(ZminPos, ZmaxPos);

        return new Vector3(x, -7.9f, z);
    }

    private void SetEnemySpawn(int EnemyType)
    {
        ParticleSystem newParticle = Instantiate(particle);
        if (EnemyType == 1)
        {
            GameObject enemy_A = Instantiate(EnemyPrefab_A);

            enemy_A.transform.position = GetRandomPosition();

            newParticle.transform.position = enemy_A.transform.position;

            enemy_A.GetComponent<NavMeshAgent>().enabled = true;


        }
        else if (EnemyType == 2)
        {
            GameObject enemy_B = Instantiate(EnemyPrefab_B);

            enemy_B.transform.position = GetRandomPosition();

            newParticle.transform.position = enemy_B.transform.position;
            enemy_B.GetComponent<NavMeshAgent>().enabled = true;
        }

        newParticle.Play();
        Destroy(newParticle.gameObject, 3.0f);
        NowSpawnCount += 1;
    }

    private void NextWave()
    {

        if (NowSpawnCount >= MaxSpawn)
        {
            SpawnStop = true;
            if (enemyObj.Length == 0 && Bullet_enemyObj.Length == 0)
            {
                if (NowWave == 4 && SpawnStop == true)
                {
                    EndWave = true;
                    return;
                }
                switch (NowWave)
                {
                    case 1:
                        enemyManager.EnemyDeathCount = 0;
                        MaxSpawn = (int)Wave.wave_2;
                        NowWave = 2;
                        NowSpawnCount = 0;
                        SpawnStop = false;
                        break;
                    case 2:
                        enemyManager.EnemyDeathCount = 0;
                        MaxSpawn = (int)Wave.wave_3;
                        NowWave = 3;
                        NowSpawnCount = 0;
                        SpawnStop = false;
                        break;
                    case 3:
                        enemyManager.EnemyDeathCount = 0;
                        MaxSpawn = (int)Wave.wave_4;
                        NowWave = 4;
                        NowSpawnCount = 0;
                        SpawnStop = false;
                        break;
                }


            }

        }
    }
}
