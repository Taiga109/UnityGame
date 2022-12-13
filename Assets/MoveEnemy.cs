using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject target;
    [SerializeField] Collider SearchCol;
    public Rigidbody rb;
    public float speed;
    private float x;
    private float z;
    void Start()
    {
        speed = 0.05f;
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        if (SearchCol.GetComponent<SearchPlayer>().isArea == true)
        {
            //GetComponent<Renderer>().material.color = Color.red;
            //transform.LookAt(target.transform);
            //rb.position += transform.forward * speed;
            GetComponent<Renderer>().material.color = Color.red;
            Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);

            lookRotation.z = 0;
            lookRotation.x = 0;

            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);

            Vector3 p = new Vector3(0f, 0f, 0.005f);

            transform.Translate(p);
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }

}
