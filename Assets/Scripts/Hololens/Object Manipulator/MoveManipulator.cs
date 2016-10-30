using UnityEngine;
using HoloToolkit.Unity;
using UnityEngine.VR.WSA.Input;
using System;

public class MoveManipulator : HipToolManipulator {


    internal override void doManipulation()
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
            targetObject.transform.position = worldObjectPosition;
        }
            
    }

}