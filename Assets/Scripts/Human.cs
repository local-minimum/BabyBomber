using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircularTransform))]
public class Human : MonoBehaviour
{
    CircularTransform ct;
    float elevation;
    float spawnAngle;

    [SerializeField]
    float minAngleOffset = -3f;

    [SerializeField]
    float maxAngleOffest = 3f;

    float angle;

    [SerializeField]
    float moveSpeed = 0.1f;

    void Start()
    {
        ct = GetComponent<CircularTransform>();
        elevation = ct.Elevation;
        spawnAngle = ct.Angle;
        angle = spawnAngle;
    }

    void Update()
    {
        angle = Mathf.Clamp(angle + (Random.value - 0.5f) * Time.deltaTime * moveSpeed, spawnAngle + minAngleOffset, spawnAngle + maxAngleOffest);
        ct.SetAnglePosition(angle, elevation);
    }
}
