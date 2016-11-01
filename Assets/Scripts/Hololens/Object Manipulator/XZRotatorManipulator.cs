using System;
using UnityEngine;

public class XZRotatorManipulator : RotatorManipulator
{
    internal override void rotate(Vector3 scaledLocalPositionDelta)
    {
        Transform _transform = targetObject.transform;
        _transform.RotateAround(_transform.position, _transform.forward, scaledLocalPositionDelta.x);
        _transform.RotateAround(_transform.position, _transform.right, scaledLocalPositionDelta.y);
    }
}