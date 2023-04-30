using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircularTransform))]
public class BabyCamera : MonoBehaviour
{
    CircularTransform ct;

    Rigidbody2D babyRb;

    private void Start()
    {
        ct = GetComponent<CircularTransform>();
    }

    bool flying;
    private void OnEnable()
    {
        babyRb = GetComponentInParent<Rigidbody2D>();
        flying = true;
        BabyCamOffHud.Active = false;
    }

    [SerializeField]
    float stationaryThreshold = 0.05f;

    float lastMove;

    [SerializeField]
    float landedDelay = 1.5f;

    private void Update()
    {
        if (babyRb == null) return;

        if (flying)
        {
            if (babyRb.velocity.magnitude < stationaryThreshold)
            {
                flying = false;
                lastMove = Time.timeSinceLevelLoad;
            }
        } else if (Time.timeSinceLevelLoad > landedDelay + lastMove)
        {           
            babyRb = null;
            transform.parent = null;
            enabled = false;
            GetComponent<Camera>().enabled = false;
            BabyLauncher.instance.readyToLaunch = true;
            BabyCamOffHud.Active = true;
            Altometer.instance.SetElevation(0);
        }

        Altometer.instance.SetElevation(ct.Elevation);
    }
}
