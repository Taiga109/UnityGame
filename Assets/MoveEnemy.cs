using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float Moveradius = 3;

    [SerializeField] public Transform playerpos;

    [SerializeField] float waitTime = 2;
   
    [SerializeField] float time = 0;
    //public Vector3[] movepoints = new Vector3[3];
    private int Mode;
    public Transform enemypos;
    private int currentRoot;
    public float speed;
   
    NavMeshAgent agent;
    void Start()
    {
        //speed = 0.05f;
      
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 pos = movepoints[currentRoot];
        float distance=Vector3.Distance(enemypos.position, playerpos.transform.position);
        if (distance > 5.0f)
        {
            Mode = 0;
            GetComponent<Renderer>().material.color = Color.white;
        }
        else if (distance < 5.0f)
        {
            Mode = 1;
            //agent.speed = 0;
            
            GetComponent<Renderer>().material.color = Color.red;
            //agent.destination = playerpos.position;
            //agent.speed = speed;
        }

        switch (Mode){
            case 0:
                //if (Vector3.Distance(transform.position, pos) < 1f)
                //{//もし敵の位置と現在の目的地との距離が1以下なら
                //    currentRoot += 1;//currentRootを+1する
                //    if (currentRoot > movepoints.Length - 1)
                //    {//もしcurrentRootがwayPointsの要素数-1より大きいなら
                //        currentRoot = 0;//currentRootを0にする
                //    }
                //}
                //agent.SetDestination(pos);//NavMeshAgentの情報を取得し目的地をposにする
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                {
                    StopHere();
                }
                  
                break;
            case 1:
                agent.isStopped = false;
                agent.destination = playerpos.transform.position;
                break;
        }
       
    }
    void GetNextPoint()
    {
        agent.isStopped = false;
        float posX = Random.Range(-1 * Moveradius, Moveradius);
        float posZ = Random.Range(-1 * Moveradius, Moveradius);
        Vector3 pos = enemypos.position;
        pos.x += posX;
        pos.z += posZ;
        agent.destination = pos;
    }

    void StopHere()
    {
        //NavMeshAgentを止める
        agent.isStopped = true;
        //待ち時間を数える
        time += Time.deltaTime;

        //待ち時間が設定された数値を超えると発動
        if (time > waitTime)
        {
            //目標地点を設定し直す
            GetNextPoint();
            time = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            agent.isStopped = true;
            //待ち時間を数える
            time += Time.deltaTime;

            //待ち時間が設定された数値を超えると発動
            if (time > waitTime)
            {
                time = 0;
            }
        }
    }
}
