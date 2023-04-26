using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_shot : MonoBehaviour
{
    public GameObject Bulletfab;

    private int count;
    [SerializeField] int shot_time;
   // [SerializeField] public Transform playerpos;

    private Vector3 playerpos;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        if (shot_time <= 0)
        {
            shot_time = 30;
        }

    }

    // Update is called once per frame
    void Update()
    {
        playerpos = Player.transform.position;
        float distance = Vector3.Distance(transform.position, playerpos);
        if (distance > 5.0f)
        {
            count++;
            if (count % shot_time == 0)
            {
                GameObject bullet = Instantiate(Bulletfab, transform.position, Quaternion.identity);
                Rigidbody bulletrb = bullet.GetComponent<Rigidbody>();
                bulletrb.useGravity = false;

                bullet.transform.LookAt(playerpos);
                
                bulletrb.AddForce(bullet.transform.forward * 10, ForceMode.Impulse);

                Destroy(bullet, 5.0f);
            }
        }

    }
}
