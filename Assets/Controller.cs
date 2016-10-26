using UnityEngine;
using System.Collections;
using System;

public class Controller : MonoBehaviour {
    public float moveSpeed = 4f;
    public float moveSpeedMultiplier = 2f;

    public float mouseSensitivy = 20f;
    private bool tabbed = false;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("tab"))
            tabbed = !tabbed;
        if (tabbed)
            control();
    }

    private void control()
    {

        //speed multiplier
        float speed = moveSpeed;
        if (Input.GetKey("left shift"))
            speed = speed * moveSpeedMultiplier;

        //In or Out
        transform.Translate(0, 0, Time.deltaTime * speed * Input.GetAxis("Mouse ScrollWheel"));

        // up, down, left and right
        if (Input.GetKey("w"))
            transform.Translate(0, Time.deltaTime * speed, 0);
        if (Input.GetKey("a"))
            transform.Translate(Time.deltaTime * speed * -1, 0, 0);
        if (Input.GetKey("s"))
            transform.Translate(0, Time.deltaTime * speed * -1, 0);
        if (Input.GetKey("d"))
            transform.Translate(Time.deltaTime * speed, 0, 0);
        if (Input.GetKey("q"))
            transform.RotateAround(transform.position, transform.forward, Time.deltaTime * speed * 3);
        if (Input.GetKey("e"))
            transform.RotateAround(transform.position, transform.forward, Time.deltaTime * speed * -3);
        rotate();
    }

    private void rotate()
    {
        float x = Time.deltaTime * Input.GetAxis("Mouse X") * -1 * mouseSensitivy;
        float y = Time.deltaTime * Input.GetAxis("Mouse Y") * mouseSensitivy;
        transform.RotateAround(transform.position, transform.up, x);
        transform.RotateAround(transform.position, transform.right, y);
    }
}
