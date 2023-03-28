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
    private Animator animator;
   
    private int currentRoot;
    public float speed;
    bool flag = false;
    NavMeshAgent agent;
    // [SerializeField] private GameObject thisObject;

    void Start()
    {
        //speed = 0.05f;

        agent = GetComponent<NavMeshAgent>();
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 pos = movepoints[currentRoot];
        float distance = Vector3.Distance(enemypos.position, playerpos.transform.position);
        Vector3 direction = (transform.position - playerpos.transform.position).normalized;
        direction.y = 0;

       

        animator.SetFloat("move", agent.velocity.sqrMagnitude);



        if (distance > 5.0f)
        {
            Mode = 0;
            //GetComponent<Renderer>().material.color = Color.white;

        }
        else if (distance < 5.0f)
        {
            if (this.gameObject.CompareTag("enemy"))
            {
                Mode = 1;
            }

            else if (Mode == 0 && this.gameObject.CompareTag("Bullet_enemy"))
            {
                Mode = 2;
            }



            //agent.destination = playerpos.position;
            //agent.speed = speed;
        }

        switch (Mode)
        {
            case 0:
             
                
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                {
                    StopHere();
                }
              
                break;
            case 1:
               // transform.LookAt(agent.destination);
                agent.destination = playerpos.transform.position;

                if (flag)
                {
                    animator.SetTrigger("Attack");
                    agent.isStopped = true;
                    //待ち時間を数える
                    time += Time.deltaTime;

                    //待ち時間が設定された数値を超えると発動
                    if (time > waitTime)
                    {
                        flag = false;
                        time = 0;
                    }
                }
                else
                {
                    agent.isStopped = false;
                }

                //if (GameObject.FindWithTag("Bullet_enemy"))
                //{

                //}
                break;
            case 2:
                // GetComponent<Renderer>().material.color = Color.blue;
                if (distance < 4.0f)
                {
                    direction = (transform.position - playerpos.transform.position).normalized;
                    agent.destination = transform.position + direction * Moveradius;
                    transform.LookAt(agent.destination);

                }
                else if (distance > 4.5)
                {
                    Mode = 0;
                }
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
            
            flag = true;
        }
    }
}
