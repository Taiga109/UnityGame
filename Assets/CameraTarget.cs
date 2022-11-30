using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] GameObject player;
    Camera cam;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        //transform.SetParent(player.gameObject.transform);
        //offset.x = transform.position.x - player.transform.position.x;
        //offset.y = transform.position.y - player.transform.position.y;
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //cam.transform.LookAt(player.gameObject.transform.position);
        transform.position = player.transform.position + offset;
    }
}
