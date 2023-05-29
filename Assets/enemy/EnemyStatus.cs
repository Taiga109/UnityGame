using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyStatus : MonoBehaviour
{   //敵のMaxHP
    [SerializeField]
    private int maxHp = 100;
    //�G�̍U����
    [SerializeField]
    //  private int attackPower = 1;
    public int currentHp;

    //�@HP�\���p�X���C�_�[
    public Slider slider;

    private Animator animator;

    private EnemyManager enemyManager;

    MoveEnemy move_enemy;
    Collider col;
    public enum EnemyState
    {
        Walk,
        Idol,
        Chase,
        Attack
    };

    // Start is called before the first frame update
    void Start()
    {
        slider.value = (float)maxHp;
        currentHp = maxHp;
        animator = GetComponent<Animator>();
        col = this.gameObject.GetComponent<Collider>();
        GameObject EnemyManagerObj = GameObject.Find("EnemyManager");
        enemyManager = EnemyManagerObj.GetComponent<EnemyManager>();

    }

    // Update is called once per frame
    void Update()
    {
        slider.transform.rotation = Camera.main.transform.rotation;

       
    }
    void OnCollisionEnter(Collision collision)
    {
    }
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("ontrriger");

        if (other.gameObject.tag == "Player_Attack")
        {
            currentHp -= 50;
            slider.value = (float)currentHp / (float)maxHp;
            if (currentHp == 0)
            {
                this.GetComponent<MoveEnemy>().enabled = false;
                col.enabled = false;
                if (this.gameObject.CompareTag("Bullet_enemy"))
                {
                    this.GetComponent<Enemy_shot>().enabled = false;
                }
                animator.SetTrigger("Dead");
                enemyManager.EnemyDeathCount += 1;
                Destroy(gameObject, 5f);
            }
        }
    }
}
