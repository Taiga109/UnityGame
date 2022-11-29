using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 4.0f;
    public float power = 6.0f;
    public Rigidbody rb;

    private float x;
    private float z;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
     
        Vector3 dir = new Vector3(x, 0, z);

        rb.velocity = new Vector3(x, 0, z) * speed;
        animator.SetFloat("run", rb.velocity.magnitude);

        if (dir.magnitude > 0.1)
        {
            Quaternion rot = Quaternion.LookRotation(dir);
            transform.rotation =
                Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * 10f);
        }
    }

    void FixedUpdate()
    {

    }
}
