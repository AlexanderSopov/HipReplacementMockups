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
        Vector3 distanceVector = transform.position - stick.transform.position;
        Vector3 rotationVector =new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z)
            - new Vector3(stick.transform.rotation.x, stick.transform.rotation.y, stick.transform.rotation.z);

        Debug.Log(rotationVector.magnitude);
        return distanceVector.magnitude < 0.2f && rotationVector.magnitude < 0.1f;
    }
}
