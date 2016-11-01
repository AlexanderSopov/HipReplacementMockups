
using UnityEngine;

public abstract class RotatorManipulator : HipToolManipulator
{
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
        Debug.Log(string.Format("Rotate using this {0} vector", scaledLocalPositionDelta.ToString()));
        // If the object has an interpolator we should use it, otherwise just move the transform directly
        rotate(scaledLocalPositionDelta);
        move(scaledLocalPositionDelta);
    }

    private void move(Vector3 scaledLocalPositionDelta)
    {

        Vector3 localObjectPosition = initialObjectPosition + new Vector3(0, 0, scaledLocalPositionDelta.z);
        Vector3 worldObjectPosition = Camera.main.transform.TransformPoint(localObjectPosition);
        if (targetInterpolator != null)
        {
            targetInterpolator.SetTargetPosition(worldObjectPosition);
        }
        else
        {
            targetObject.transform.position = worldObjectPosition;
        }
    }

    internal abstract void rotate(Vector3 scaledLocalPositionDelta);

}