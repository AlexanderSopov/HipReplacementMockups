using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
    public float moveSpeed = 2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        if (Input.GetKey("s"))
            transform.Translate(0, Time.deltaTime * moveSpeed * -1, 0);
        if (Input.GetKey("w"))
            transform.Translate(0, Time.deltaTime * moveSpeed, 0);

    }
}
