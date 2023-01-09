using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] GameObject player;
    Camera cam;
    [SerializeField] Vector3 offset;
    public float rotateSpeed = 2.0f;
    private float angleUp = 60f;
    private float angleDown = -20f;
    private float angleRight = 40f;
    private float angleLeft = -40f;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        //transform.SetParent(player.gameObject.transform);
        //offset.x = transform.position.x - player.transform.position.x;
        //offset.y = transform.position.y - player.transform.position.y;
        //offset = transform.position - player.transform.position;
        cam.transform.localPosition = new Vector3(0, 0, -3);
        cam.transform.localRotation = transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        //cam.transform.LookAt(player.gameObject.transform.position);
        transform.position = player.transform.position + offset;
        rotateCamera();
      
    }

    private void rotateCamera()
    {
        //Vector3 angle = new Vector3
        //    (Input.GetAxis("Mouse X") * -rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed, 0);


        //cam.transform.RotateAround(player.transform.position, Vector3.up, angle.x);
        //cam.transform.RotateAround(player.transform.position, Vector3.right, angle.y);

        transform.eulerAngles += new Vector3(
         Input.GetAxis("Mouse Y") * -rotateSpeed,
         Input.GetAxis("Mouse X") * rotateSpeed
         , 0);

        float angleX = transform.eulerAngles.x;

        if (angleX >= 180)
        {
            angleX = angleX - 360;
        }

        float angleY = transform.eulerAngles.y;

        if (angleY >= 180)
        {
            angleY = angleY - 360;
        }

        //transform.eulerAngles = new Vector3(
        //   Mathf.Clamp(angleX, angleDown, angleUp),
        //   transform.eulerAngles.y,
        //   transform.eulerAngles.z);
        transform.eulerAngles = new Vector3(
           Mathf.Clamp(angleX, angleDown, angleUp),
           Mathf.Clamp(angleY, angleLeft, angleRight),
           transform.eulerAngles.z);
    }
}
