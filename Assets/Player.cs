using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{

    public float speed = 4.0f;
    private float defspeed;
    public float power = 6.0f;
    public Rigidbody rb;

    private float x;
    private float z;
    private Animator animator;
    private bool IsAttack = false;

    public int MaxHp = 100;
    public int currentHp;

    public Slider slider;

    [SerializeField] Collider AttackCol;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 1;
        currentHp = MaxHp;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        defspeed = speed;

        // attackObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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

        if (Input.GetMouseButtonDown(0))
        {

            animator.SetTrigger("attack");
            AttackCol.enabled = true;
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


        rb.velocity = new Vector3(x, 0, z) * speed;
        animator.SetFloat("run", rb.velocity.magnitude);
        if (dir.magnitude > 0.1)
        {
            Quaternion rot = Quaternion.LookRotation(dir);
            transform.rotation =
                Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * 10f);
        }

        if (currentHp < 0)
        {
            SceneManager.LoadScene("GameOver");
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            int damage = Random.Range(10, 50);

            currentHp = currentHp - damage;

            slider.value = (float)currentHp / (float)MaxHp;
        }
    }



    private void ColliderOff()
    {
        AttackCol.enabled = false;
    }


    void FixedUpdate()
    {

    }
}
