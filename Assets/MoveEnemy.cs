using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float WaldSpeed = 1.0f;
    private Vector3 velocity;
    private Vector3 direction;

    private bool arrived;

    [SerializeField]
    private float waitTime = 5f;

    private float elapsedTime;


    void Start()
    {
        velocity = Vector3.zero;
        elapsedTime = 0f;
        arrived = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!arrived)
        {
            
        }
    }
}
