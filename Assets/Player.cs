using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;
public class Player : MonoBehaviour
{
    //  public GameObject fadeCanvas;
    public float speed = 4.0f;
    private float defspeed;
    public float power = 6.0f;
    public Rigidbody rb;

    private float x;
    private float z;
    private Animator animator;
    private bool IsAttack = false;

    public bool CD = false;
    public float CDcount = 0;

    public int MaxHp = 100;
    public int currentHp;
    private string NextScene;
    public Slider slider;

    CapsuleCollider PlayerCollision;

    [SerializeField] Collider R_Hand_AttackCol;
    [SerializeField] Collider L_Hand_AttackCol;
    [SerializeField] Collider R_Leg_AttackCol;
    [SerializeField] Collider L_Leg_AttackCol;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 1;
        currentHp = MaxHp;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        defspeed = speed;

        PlayerCollision = GetComponent<CapsuleCollider>();
        // attackObj.SetActive(false);
        //if (!FadeManager.isFadeInstance)
        //{
        //    Instantiate(fadeCanvas);
        //}
        //Invoke("findFadeObject", 0.02f);
    }
    //void findFadeObject()
    //{
    //    fadeCanvas = GameObject.FindGameObjectWithTag("Fade");
    //    fadeCanvas.GetComponent<FadeManager>().fadeIn();
    //}

    //public async void ChangeScene(string nextScene)
    //{
    //    fadeCanvas.GetComponent<FadeManager>().fadeOut();
    //    await Task.Delay(200);
    //    SceneManager.LoadScene(nextScene);
    //}
    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (PlayerCollision.enabled == true)
        {
            if (collision.gameObject.CompareTag("enemy"))
            {
                int damage = Random.Range(5, 10);

                currentHp = currentHp - damage;

                slider.value = (float)currentHp / (float)MaxHp;
            }

            if (collision.gameObject.CompareTag("Bullet"))
            {
                int damage = 5;

                currentHp = currentHp - damage;

                slider.value = (float)currentHp / (float)MaxHp;

            }
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }


    }

    private void Rolling()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Roll"))
        {
            PlayerCollision.enabled = false;
        }
        else
        {
            PlayerCollision.enabled = true;


        }
        if (CD) { CDcount++; }

        if (CDcount > 40)
        {
            CD = false;
            CDcount = 0;
        }
    }

    private void ColliderOff()
    {
        R_Hand_AttackCol.enabled = false;
        L_Hand_AttackCol.enabled = false;

        R_Leg_AttackCol.enabled = false;
        L_Leg_AttackCol.enabled = false;

    }

    public int GetCurrentHp()
    {
        return currentHp;
    }
    void FixedUpdate()
    {
        Rolling();

        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
        {
            rb.velocity = new Vector3(0, 0, 0);
            return;
        }
        else
        {
            IsAttack = false;
        }
        if (IsAttack)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CD == false)
            {
                animator.SetTrigger("Roll");
                CD = true;
            }


        }

        if (Input.GetMouseButtonDown(0))
        {

            animator.SetTrigger("attack");
            R_Hand_AttackCol.enabled = true;
            Invoke("ColliderOff", 0.5f);
            IsAttack = true;

            return;
        }

        if (Input.GetMouseButtonDown(1))
        {

            animator.SetTrigger("attack_2");
            R_Hand_AttackCol.enabled = true;
            Invoke("ColliderOff", 0.5f);
            IsAttack = true;

            return;
        }
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x, 0, z);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = defspeed * 2.5f;
        }
        else
        {
            speed = defspeed;
        }


        rb.velocity = dir * speed;
        //transform.Translate((dir * speed));
        animator.SetFloat("run", rb.velocity.magnitude);
        if (dir.magnitude > 0.1)
        {
            Quaternion rot = Quaternion.LookRotation(dir);
            transform.rotation =
                Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * 10f);
        }


        if (currentHp < 0)
        {

            NextScene = "GameOver";
            //ChangeScene(NextScene);
            SceneManager.LoadScene(NextScene);
        }
    }
}
