using UnityEngine;
using System.Collections;
using System;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float moveSpeedMultiplier = 10f;

    public float mouseSensitivy = 20.0f;
    public float rotationStop = 90.0f;
    private float _rotationStop;
    private bool tabbed = false;
    // Use this for initialization
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("tab") || Input.GetKeyDown("mouse 0"))
            tabbed = !tabbed;
        if (tabbed)
            return;
        float speed = moveSpeed;
        if (Input.GetKey("left shift"))
            speed = speed * moveSpeedMultiplier;
        if (Input.GetKey("s"))
            transform.Translate(0, 0, Time.deltaTime * speed * -1);
        if (Input.GetKey("w"))
            transform.Translate(0, 0, Time.deltaTime * speed);
        if (Input.GetKey("d"))
            transform.Translate(Time.deltaTime * speed, 0, 0);
        if (Input.GetKey("a"))
            transform.Translate(Time.deltaTime * -1 * speed, 0, 0);
        rotate();

    }

    private void rotate()
    {
        float x = Time.deltaTime * Input.GetAxis("Mouse X") * mouseSensitivy;
        float y = Time.deltaTime  * Input.GetAxis("Mouse Y") * mouseSensitivy;
        transform.RotateAround(transform.position, Vector3.up, x);
        transform.RotateAround(transform.position, transform.right, -y);
    }
}
