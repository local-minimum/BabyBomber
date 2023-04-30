using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularTransform : MonoBehaviour
{
    public Vector3 Down { get => -transform.position.normalized; }

    public Vector3 Up { get => transform.position.normalized; }

    public Vector3 AngularForward
    {
        get
        {
            var down = Down;
            return new Vector3(-down.y, down.x);
        }
    }

    public float ForwardMagnitude(Vector3 v) => Vector3.Dot(AngularForward, v);
    public float Elevation
    {
        get
        {
            var pos = transform.position;
            return Mathf.Sqrt(Mathf.Pow(pos.x, 2) + Mathf.Pow(pos.y, 2));
        }
    }

    public float Angle
    {
        get
        {
            var pos = transform.position;
            return Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        }
    }

    public void SetAnglePosition(float angle, float elevation)
    {
        var rad = angle * Mathf.Deg2Rad;
        var y = Mathf.Sin(rad);
        var x = Mathf.Cos(rad);
        transform.position = new Vector3(x * elevation, y * elevation);
    }
}
