using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] Collider AttackCol;
    // Start is called before the first frame update
    void Start()
    {
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


    }
    private void ColliderOff()
    {
        AttackCol.enabled = false;
    }


    void FixedUpdate()
    {

    }
}
