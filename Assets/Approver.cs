using UnityEngine;
using System.Collections;
using System;

public class Approver : MonoBehaviour {

    public GameObject stick;
    public Material material;
    
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (withinRange())
            turnGreen();
        else
            turnRed();
	}

    private void turnRed()
    {
        material.color = new Color(1,0,0,0.2f);
    }

    private void turnGreen()
    {
        material.color = new Color(0, 1, 0, 0.2f);
    }

    private bool withinRange()
    {
        Vector3 distance = transform.position - stick.transform.position;
        return distance.magnitude < 0.2f;
    }
}
