using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircularTransform))]
public class BabyCamera : MonoBehaviour
{
    CircularTransform ct;

    private void Start()
    {
        ct = GetComponent<CircularTransform>();
    }

    private void Update()
    {
        Altometer.instance.SetElevation(ct.Elevation);
    }
}
