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

    [SerializeField]
    Transform flipTarget;

    CircularTransform ct;

    private void Start()
    {
        ct = GetComponent<CircularTransform>();
        rb = GetComponent<Rigidbody2D>();
    }

    float flipThreshold = 0.1f;

    private void Update()
    {
        var angular = ct.AngularForward;
        var forwardMagnitude = ct.ForwardMagnitude(rb.velocity);
        var absForwardMagnitude = Mathf.Abs(forwardMagnitude);

        if (Input.GetButton("Horizontal"))
        {
            var forward = Input.GetAxis("Horizontal");
            rb.AddForce(angular * forward * forwardForceByVelocity.Evaluate(absForwardMagnitude) * Time.deltaTime, ForceMode2D.Impulse);
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

        rb.AddForce(-1f * ct.Down * liftByForwardSpeed.Evaluate(absForwardMagnitude) * Time.deltaTime, ForceMode2D.Impulse);

        // Orienting the Stork
        if (forwardMagnitude > flipThreshold && flipTarget.localScale.x < 0)
        {
            flipTarget.localScale = Vector3.one;
        } else if (forwardMagnitude < -flipThreshold && flipTarget.localScale.x > 0)
        {
            flipTarget.localScale = new Vector3(-1, 1, 1);
        }
    }
}
