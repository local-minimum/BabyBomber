using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularTransform : MonoBehaviour
{
    public Vector3 Down { get => -transform.position.normalized; }

    public Vector3 Up { get => transform.position.normalized; }


    public Vector3 AngularDirection
    {
        get
        {
            var down = Down;
            return new Vector3(-down.y, down.x);
        }
    }
    public float Elevation
    {
        get
        {
            var pos = transform.position;
            return Mathf.Sqrt(Mathf.Pow(pos.x, 2) + Mathf.Pow(pos.y, 2));
        }
    }

}
