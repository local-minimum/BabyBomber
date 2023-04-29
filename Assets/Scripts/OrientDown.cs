using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class OrientDown : MonoBehaviour
{
    Vector3 Up
    {
        get => transform.position.normalized * -1f;
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, -Mathf.Sign(transform.position.x) * Vector3.Angle(Vector3.down, Up));
    }
}
