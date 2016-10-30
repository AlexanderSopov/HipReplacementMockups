using UnityEngine;
using HoloToolkit.Unity;
using UnityEngine.VR.WSA.Input;

public class MoveManipulator : GestureManipulator {

    public GameObject target;

    private void BeginManipulation(InteractionSourceKind sourceKind)
    {
        // Check if the gesture manager is not null, we're currently focused on this Game Object, and a current manipulation is in progress.
        if (gestureManager != null && gestureManager.FocusedObject != null && gestureManager.FocusedObject == gameObject && gestureManager.ManipulationInProgress)
        {
            Manipulating = true;

            targetInterpolator = target.GetComponent<Interpolator>();

            // In order to ensure that any manipulated objects move with the user, we do all our math relative to the camera,
            // so when we save the initial manipulation position and object position we first transform them into the camera's coordinate space
            initialManipulationPosition = Camera.main.transform.InverseTransformPoint(gestureManager.ManipulationPosition);
            initialObjectPosition = Camera.main.transform.InverseTransformPoint(transform.position);
        }
    }
    // Use this for initialization
    void Start () {
        //target = GameObject.FindGameObjectsWithTag("Tool")[0];
	}

    // Update is called once per frame
    void Update()
    {
        if (Manipulating)
        {
            // First step is to figure out the delta between the initial manipulation position and the current manipulation position
            Vector3 localManipulationPosition = Camera.main.transform.InverseTransformPoint(gestureManager.ManipulationPosition);
            Vector3 initialToCurrentPosition = localManipulationPosition - initialManipulationPosition;

            // When performing a manipulation gesture, the manipulation generally only translates a relatively small amount.
            // If we move the object only as much as the input source itself moves, users can only make small adjustments before
            // the source is lost and the gesture completes.  To improve the usability of the gesture we scale each
            // axis of movement by some amount (camera relative).  This value can be changed in the editor or
            // at runtime based on the needs of individual movement scenarios.
            Vector3 scaledLocalPositionDelta = Vector3.Scale(initialToCurrentPosition, PositionScale);

            // Once we've figured out how much the object should move relative to the camera we apply that to the initial
            // camera relative position.  This ensures that the object remains in the appropriate location relative to the camera
            // and the input source as the camera moves.  The allows users to use both gaze and gesture to move objects.  Once they
            // begin manipulating an object they can rotate their head or walk around and the object will move with them
            // as long as they maintain the gesture, while still allowing adjustment via input movement.
            Vector3 localObjectPosition = initialObjectPosition + scaledLocalPositionDelta;
            Vector3 worldObjectPosition = Camera.main.transform.TransformPoint(localObjectPosition);

            // If the object has an interpolator we should use it, otherwise just move the transform directly

            if (targetInterpolator != null)
            {
                targetInterpolator.SetTargetPosition(worldObjectPosition);
            }
            else
            {
                target.transform.position = worldObjectPosition;
            }

        }
    }
}