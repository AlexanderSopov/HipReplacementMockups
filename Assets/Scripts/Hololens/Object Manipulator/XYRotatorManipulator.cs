using UnityEngine;
using System.Collections;
using System;

public class XYRotatorManipulator : RotatorManipulator
{
    internal override void rotate(Vector3 scaledLocalPositionDelta)
    {
        Transform _transform = targetObject.transform;
        _transform.RotateAround(_transform.position, _transform.up, scaledLocalPositionDelta.x);
        _transform.RotateAround(_transform.position, _transform.right, scaledLocalPositionDelta.y);
    }
}