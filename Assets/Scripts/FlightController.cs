using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircularTransform))]
public class FlightController : MonoBehaviour
{
    [SerializeField]
    AnimationCurve forwardForceByVelocity;

    [SerializeField]
    AnimationCurve liftByForwardSpeed;

    Rigidbody2D rb;

    [SerializeField]
    float upForce = 5f;

    [SerializeField]
    float downForce = 20f;

    [SerializeField]
    float anglePerSecond = 30f;

    CircularTransform ct;

    private void Start()
    {
        ct = GetComponent<CircularTransform>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var angular = ct.AngularDirection;
        var forwardMagnitude = Vector3.Project(rb.velocity, angular).magnitude;

        if (Input.GetButton("Horizontal"))
        {
            var forward = Input.GetAxis("Horizontal");
            rb.AddForce(angular * forward * forwardForceByVelocity.Evaluate(forwardMagnitude) * Time.deltaTime, ForceMode2D.Impulse);
        }

        if (Input.GetButton("Vertical"))
        {
            var down = ct.Down;
            var up = Input.GetAxis("Vertical");
            if (up > 0)
            {
                rb.AddForce(-1f * down * up * upForce * Time.deltaTime, ForceMode2D.Impulse);
                rb.velocity = Vector3.RotateTowards(rb.velocity, -down, anglePerSecond * Mathf.Deg2Rad * Time.deltaTime, 0);
            } else
            {
                rb.AddForce(-1f * down * up * downForce * Time.deltaTime, ForceMode2D.Impulse);
                rb.velocity = Vector3.RotateTowards(rb.velocity, down, anglePerSecond * Mathf.Deg2Rad * Time.deltaTime, 0);
            }
        }

        rb.AddForce(-1f * ct.Down * liftByForwardSpeed.Evaluate(forwardMagnitude) * Time.deltaTime, ForceMode2D.Impulse);
    }
}
