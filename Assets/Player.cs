using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 8.0f;

    public Rigidbody rb;

    float moveX = 0.0f;
    float moveZ = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * speed;
        moveZ = Input.GetAxis("Vertical") * speed;
        Vector3 dir = new Vector3(moveX, 0, moveZ);
    }

    void FixedUpdate()
    {
      rb.velocity = new Vector3(moveX, 0, moveZ);
    }
}
