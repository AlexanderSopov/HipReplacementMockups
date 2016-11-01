using UnityEngine;
using HoloToolkit.Unity;
using UnityEngine.VR.WSA.Input;
using System.Collections;

public abstract class HipToolManipulator : GestureManipulator
{

    public GameObject targetObject;

    protected Quaternion initialObjectRotation;

    private void BeginManipulation(InteractionSourceKind sourceKind)
    {
        // Check if the gesture manager is not null, we're currently focused on this Game Object, and a current manipulation is in progress.
        if (gestureManager != null && gestureManager.FocusedObject != null && gestureManager.FocusedObject == gameObject && gestureManager.ManipulationInProgress)
        {
            Manipulating = true;

            targetInterpolator = targetObject.GetComponent<Interpolator>();

            // In order to ensure that any manipulated objects move with the user, we do all our math relative to the camera,
            // so when we save the initial manipulation position and object position we first transform them into the camera's coordinate space
            initialManipulationPosition = Camera.main.transform.InverseTransformPoint(gestureManager.ManipulationPosition);
            initialObjectPosition = Camera.main.transform.InverseTransformPoint(transform.position);
            initialObjectRotation = Camera.main.transform.rotation;

        }
    }
    // Use this for initialization
    void Start()
    {
        //target = GameObject.FindGameObjectsWithTag("Tool")[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Manipulating)
        {
            doManipulation();
        }
    }

    internal abstract void doManipulation();
}