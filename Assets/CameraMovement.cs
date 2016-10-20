using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public float mouseSensitivy = 2.0f;
    public float rotationStop = 90.0f;
    private float _rotationStop;
    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        float x = -1 * Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivy;
        float y = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivy;
        transform.Rotate(new Vector3(x, y, 0) );
	}
}
