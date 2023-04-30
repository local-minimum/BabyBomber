using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircularTransform))]
public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    float minElevation = 100f;
    [SerializeField]
    float minSize = 20f;

    [SerializeField]
    float maxElevation = 200f;

    [SerializeField]
    float maxSize = 40f;

    [SerializeField]
    Camera cam;

    Rigidbody2D rb;
    CircularTransform ct;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ct = GetComponent<CircularTransform>();
    }

    float CamSize
    {
        get
        {
            return Mathf.Lerp(minSize, maxSize, (ct.Elevation - minElevation) / (maxElevation - minElevation));
        }
    }

    void Update()
    {
        cam.orthographicSize = CamSize;
    }
}
