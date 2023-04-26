using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawn : MonoBehaviour
{
    public GameObject EnemyPrefab_A;

    public GameObject EnemyPrefab_B;
    //��������
    private float interval;
    //����
    private float time = 0f;

    //�����_���X�|�[�����W
    //X�ŏ�
    public float XminPos = -30f;
    //X�ő�
    public float XmaxPos = 30f;

    //Z�ŏ�
    public float ZminPos = -30f;
    //Z�ő�
    public float ZmaxPos = 30f;

    int EnemyType = 0;
    // Start is called before the first frame update
    void Start()
    {
        interval = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > interval)
        {

           // GetRandomEnemyType(EnemyType);
            EnemyType = Random.Range(1, 3);

            if (EnemyType == 1)
            {
                GameObject enemy_A = Instantiate(EnemyPrefab_A);

                enemy_A.transform.position = GetRandomPosition();
                enemy_A.GetComponent<NavMeshAgent>().enabled = true;

            }
            else if (EnemyType == 2)
            {
                GameObject enemy_B = Instantiate(EnemyPrefab_B);

                enemy_B.transform.position = GetRandomPosition();
                enemy_B.GetComponent<NavMeshAgent>().enabled = true;
            }
            
            time = 0f;

        }
    }

    //�����_���ʒu����
    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(XminPos, XmaxPos);
        float z = Random.Range(ZminPos, ZmaxPos);

        return new Vector3(x, -7.9f, z);
    }

    private int GetRandomEnemyType(int EnemyType)
    {
        EnemyType = Random.Range(1, 3);

        return EnemyType;
    }
}
