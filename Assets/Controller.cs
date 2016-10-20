using UnityEngine;
using System.Collections;
using System;

public class Controller : MonoBehaviour {
    public float moveSpeed = 4f;
    public float moveSpeedMultiplier = 2f;

    public float mouseSensitivy = 20f;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(0))
            return;
        float speed = moveSpeed;
        if (Input.GetKey("left shift"))
            speed = speed * moveSpeedMultiplier;
        if (Input.GetKey("s"))
            transform.Translate(0, Time.deltaTime * speed * -1, 0);
        if (Input.GetKey("w"))
            transform.Translate(0, Time.deltaTime * speed, 0);
        if (Input.GetKey("a"))
            transform.Translate(0,0,Time.deltaTime * speed * -1);
        if (Input.GetKey("d"))
            transform.Translate(0, 0, Time.deltaTime * speed);
        rotate();

    }

    private void rotate()
    {
        float x = Time.deltaTime * Input.GetAxis("Mouse X") * -1 * mouseSensitivy;
        float y = Time.deltaTime * Input.GetAxis("Mouse Y") * mouseSensitivy;
        transform.RotateAround(transform.position, transform.right, x);
        transform.RotateAround(transform.position, transform.forward, y);
    }
}
