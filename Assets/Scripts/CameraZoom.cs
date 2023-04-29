using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    float Elevation
    {
        get
        {
            return transform.position.magnitude;
        }
    }

    float CamSize
    {
        get
        {
            return Mathf.Lerp(minSize, maxSize, (Elevation - minElevation) / (maxElevation - minElevation));
        }
    }

    void Update()
    {
        cam.orthographicSize = CamSize;
    }
}
